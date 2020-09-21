using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Web.Api.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetErrorMessages(this ModelStateDictionary modelState)
        {
            var msg = string.Join(',', modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
            return msg;
        }
    }
}
