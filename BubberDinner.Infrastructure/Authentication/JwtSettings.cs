using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Infrastructure.Authentication
{
    public class JwtSettings

    {
        public const string SectionName = "JwtSettings";

        public string? Secrets { get; set; } = null!;
        public int ExpirayMinute { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
