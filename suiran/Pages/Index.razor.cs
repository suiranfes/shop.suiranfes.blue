using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace suiran.Pages;

public partial class IndexBase : ComponentBase
{
    [Inject]
    public HttpClient? Http { get; set; }

    public DocsData[]? docsData;

    protected override async Task OnInitializedAsync()
    {
        // Ignore the cache of `sample-data/docs.json`
        var cacheBuster = new DateTime().ToString("yyyyMMddHHmmss");
        var url = $"sample-data/docs.json?{cacheBuster}";
        if (Http != null)
            docsData = await Http.GetFromJsonAsync<DocsData[]>(url);

        visibility = "visible";
        ChangePages(page);

        // Preload images
        if (docsData != null && Http != null)
            foreach (var imageURL in docsData)
            {
                (await Http.GetAsync(imageURL.DocsImage, HttpCompletionOption.ResponseHeadersRead)).EnsureSuccessStatusCode();
            }
    }

    public class DocsData
    {
        public string? DocsTitle { get; set; }
        public string? DocsDescription { get; set; }
        public string? DocsImage { get; set; }
    }

    public int page = 0;
    public string headerArea = "";
    public string textArea = "";
    public string imageArea = "";

    public string visibility = "hidden"; // for quick show

    public void Next()
    {
        if (docsData != null && page == docsData.Length - 1)
            return;
        page++;
        ChangePages(page);
    }

    public void Previous()
    {
        if (page == 0)
            return;
        page--;
        ChangePages(page);
    }

    public void ChangePages(int _page)
    {
        if (docsData == null)
            return;
        headerArea = docsData[_page].DocsTitle ?? "";
        textArea = docsData[_page].DocsDescription ?? "";
        imageArea = docsData[_page].DocsImage ?? "";
        visibility = (imageArea == "") ? "hidden" : "visible";
    }
}
