using AstroHoraZ.SeoToolkit.DynamicSitemap.Models;

namespace AstroHoraZ.SeoToolkit.DynamicSitemap.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly IConfiguration _configuration;

        public SitemapService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<List<SitemapUrl>> GetUrlsAsync(string language = "en")
        {
            var baseUrl = _configuration["AppSettings:BaseUrl"];

            var urls = new List<SitemapUrl>
    {
        // Home
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}",
            ChangeFrequency = "daily",
            Priority = 1.0m
        },

        // Horoscope
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/kundli",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/kundli-matching",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/prashnakundali",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/panchangam",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/gowri-panchangam",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/choghadiya",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/astrology-tools",
            ChangeFrequency = "weekly",
            Priority = 0.9m
        },
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/hora",
            ChangeFrequency = "daily",
            Priority = 0.9m
        },
        // Numerology
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/numerology/name-numerology-calculator",
            ChangeFrequency = "weekly",
            Priority = 0.8m
        },
         new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/numerology/birthdate-Compatibility",
            ChangeFrequency = "weekly",
            Priority = 0.8m
        },
          new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/numerology/business-name-numerology-calculator",
            ChangeFrequency = "weekly",
            Priority = 0.8m
        },
         new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/blog",
            ChangeFrequency = "weekly",
            Priority = 0.8m
        },

        // About
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/about",
            ChangeFrequency = "monthly",
            Priority = 0.7m
        },

        // Services
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/services",
            ChangeFrequency = "monthly",
            Priority = 0.7m
        },

        // Contact
        new SitemapUrl
        {
            Url = $"{baseUrl}/{language}/contact",
            ChangeFrequency = "yearly",
            Priority = 0.5m
        }
    };

            return Task.FromResult(urls);
        }
    }
}