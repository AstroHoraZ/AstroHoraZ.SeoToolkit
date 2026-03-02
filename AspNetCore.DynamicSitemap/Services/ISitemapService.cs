using AstroHoraZ.SeoToolkit.DynamicSitemap.Models;

namespace AstroHoraZ.SeoToolkit.DynamicSitemap.Services
{
    public interface ISitemapService
    {
        Task<List<SitemapUrl>> GetUrlsAsync(string language = "en");
    }
}