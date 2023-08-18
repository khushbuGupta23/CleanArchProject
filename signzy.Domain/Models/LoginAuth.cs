using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signzy.Domain.Models
{
    public class LoginAuth
    {
        public string? id { get; set; }
        public int ttl { get; set; }
        public string? created { get; set; }
        public string? userId { get; set; }
        public string? Token { get; set; }
    }
}
