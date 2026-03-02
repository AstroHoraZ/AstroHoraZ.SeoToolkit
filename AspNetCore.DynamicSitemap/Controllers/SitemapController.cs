using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using AstroHoraZ.SeoToolkit.DynamicSitemap.Models;
using AstroHoraZ.SeoToolkit.DynamicSitemap.Services;

namespace AstroHoraZ.SeoToolkit.DynamicSitemap.Controllers
{
    [ApiController]
    public class SitemapController : ControllerBase
    {
        private readonly ISitemapService _sitemapService;
        private readonly IConfiguration _configuration;

        public SitemapController(ISitemapService sitemapService, IConfiguration configuration)
        {
            _sitemapService = sitemapService;
            _configuration = configuration;
        }

        [HttpGet("sitemap-{lang}.xml")]
        public async Task<IActionResult> LanguageSitemap(string lang = "en")
        {
            var urls = await _sitemapService.GetUrlsAsync(lang);
            var xml = GenerateSitemapXml(urls);
            return Content(xml, "application/xml", Encoding.UTF8);
        }

        [HttpGet("sitemap.xml")]
        public async Task<IActionResult> DefaultSitemap()
        {
            var urls = await _sitemapService.GetUrlsAsync("en");
            var xml = GenerateSitemapXml(urls);
            return Content(xml, "application/xml", Encoding.UTF8);
        }

        [HttpGet("sitemap-index.xml")]
        public IActionResult SitemapIndex()
        {
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            var languages = new[] { "en", "hi", "ta", "te", "kn", "ml" };

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };

            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("sitemapindex", "http://www.sitemaps.org/schemas/sitemap/0.9");

            foreach (var lang in languages)
            {
                xmlWriter.WriteStartElement("sitemap");
                xmlWriter.WriteElementString("loc", $"{baseUrl}/sitemap-{lang}.xml");
                xmlWriter.WriteElementString("lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"));
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            return Content(stringWriter.ToString(), "application/xml", Encoding.UTF8);
        }

        private string GenerateSitemapXml(List<SitemapUrl> urls)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };

            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
            xmlWriter.WriteAttributeString("xmlns", "image", null,
                "http://www.google.com/schemas/sitemap-image/1.1");

            foreach (var url in urls)
            {
                xmlWriter.WriteStartElement("url");
                xmlWriter.WriteElementString("loc", url.Url);
                xmlWriter.WriteElementString("lastmod", url.LastModified.ToString("yyyy-MM-dd"));
                xmlWriter.WriteElementString("changefreq", url.ChangeFrequency);
                xmlWriter.WriteElementString("priority", url.Priority.ToString("0.0"));

                if (!string.IsNullOrEmpty(url.ImageUrl))
                {
                    xmlWriter.WriteStartElement("image", "image",
                        "http://www.google.com/schemas/sitemap-image/1.1");

                    xmlWriter.WriteElementString("image", "loc",
                        "http://www.google.com/schemas/sitemap-image/1.1",
                        url.ImageUrl);

                    if (!string.IsNullOrEmpty(url.ImageTitle))
                    {
                        xmlWriter.WriteElementString("image", "title",
                            "http://www.google.com/schemas/sitemap-image/1.1",
                            url.ImageTitle);
                    }

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            return stringWriter.ToString();
        }
    }
}