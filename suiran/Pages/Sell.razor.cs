using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Blazored.SessionStorage;
using QRCoder;

namespace suiran.Pages;

public partial class SellBase : ComponentBase
{
    [Inject]
    public HttpClient? Http { get; set; }
    [Inject]
    public ISessionStorageService? SessionStorage { get; set; }

    public ItemData[]? itemData;

    protected override async Task OnInitializedAsync()
    {
        // Read json file
        // (Ignore the cache of `sample-data/item.json`)
        var cacheBuster = new DateTime().ToString("yyyyMMddHHmmss");
        var url = $"sample-data/item.json?{cacheBuster}";
        if (Http != null)
            itemData = await Http.GetFromJsonAsync<ItemData[]>(url);

        // Load session storage
        if (itemData != null)
            foreach (var item in itemData)
            {
                if (SessionStorage != null && int.TryParse(await SessionStorage.GetItemAsync<string>("data-" + item.ItemName), out int outData))
                    item.ItemNum = outData;
                else
                    item.ItemNum = 0;
            }

        // Preload images
        if (itemData != null && Http != null)
            foreach (var imageURL in itemData)
            {
                (await Http.GetAsync(imageURL.ItemImage, HttpCompletionOption.ResponseHeadersRead)).EnsureSuccessStatusCode();
            }
    }

    public class ItemData
    {
        public string? ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int ItemNum = 0;
        public int ItemPrices => ItemPrice * ItemNum;
        public string? ItemImage { get; set; }
    }

    public void AllDel()
    {
        if (itemData != null)
        {
            foreach (var item in itemData)
            {
                item.ItemNum = 0;
            }
        }
        StateHasChanged(); // UIの再描画
    }

    public int AllPrices = 0;
    public string qrContent = "";
    public string QRCodeStr = string.Empty;
    public void QR()
    {
        // 合計金額を求める処理
        AllPrices = 0;
        if (itemData != null)
        {
            foreach (var item in itemData)
            {
                AllPrices += item.ItemPrices;
            }
        }

        // QRコード作成処理(遅いので非同期処理にする予定)
        qrContent = "";
        if (itemData != null)
        {
            foreach (var item in itemData)
            {
                string temp = "";
                if (item.ItemName is not null)
                    temp = item.ItemName;
                qrContent += temp + ", ";
                qrContent += item.ItemPrice.ToString() + ", ";
                qrContent += item.ItemNum.ToString() + ", ";
                qrContent += item.ItemPrices.ToString() + "; ";
            }
        }
        QRCodeStr = GenerateQR(qrContent);
        // qrContent = string.Empty;
        StateHasChanged(); // UIの再描画
    }

    public async void Declement(ItemData item)
    {
        if (item.ItemNum != 0)
        {
            item.ItemNum--;
            if (SessionStorage != null)
                await SessionStorage.SetItemAsStringAsync("data-" + item.ItemName, "");
        }
        StateHasChanged(); // UIの再描画
    }

    public async void Plus(ItemData item)
    {
        item.ItemNum++;
        if (SessionStorage != null)
            await SessionStorage.SetItemAsStringAsync("data-" + item.ItemName, item.ItemNum.ToString());
        StateHasChanged(); // UIの再描画
    }

    public static string GenerateQR(string input)
    {
        QRCodeGenerator qrGenerator = new();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.M);
        PngByteQRCode qrCode = new(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);
        var qrString = "data:image/png;base64," + Convert.ToBase64String(qrCodeImage.ToArray());
        return qrString;
    }
}
