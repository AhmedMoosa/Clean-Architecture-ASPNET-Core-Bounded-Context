using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Web.Api.Models
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
    }
}
