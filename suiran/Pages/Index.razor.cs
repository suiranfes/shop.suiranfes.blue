using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace suiran.Pages;

public partial class IndexBase : ComponentBase
{
    [Inject]
    public HttpClient? Http { get; set; }

    public DocsData[]? docs_data;

    protected override async Task OnInitializedAsync()
    {
        // Ignore the cache of `sample-data/docs.json`
        var cacheBuster = new DateTime().ToString("yyyyMMddHHmmss");
        var url = $"sample-data/docs.json?{cacheBuster}";
        if (Http != null)
            docs_data = await Http.GetFromJsonAsync<DocsData[]>(url);

        visibility = "visible";
        ChangePages(page);
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
        if (docs_data != null && page == docs_data.Length - 1)
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
        if (docs_data == null)
            return;
        headerArea = docs_data[_page].DocsTitle ?? "";
        textArea = docs_data[_page].DocsDescription ?? "";
        imageArea = docs_data[_page].DocsImage ?? "";
        visibility = (imageArea == "") ? "hidden" : "visible";
    }
}
