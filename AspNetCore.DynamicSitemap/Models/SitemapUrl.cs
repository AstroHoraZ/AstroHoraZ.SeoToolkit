using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroHoraZ.SeoToolkit.DynamicSitemap.Models
{
    public class SitemapUrl
    {
        public string Url { get; set; } = string.Empty;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public string ChangeFrequency { get; set; } = "weekly";
        public decimal Priority { get; set; } = 0.8m;

        // Optional Image Support
        public string? ImageUrl { get; set; }
        public string? ImageTitle { get; set; }
    }
}
