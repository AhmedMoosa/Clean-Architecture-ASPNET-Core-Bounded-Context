using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Users.Core.Entities
{
    [Table("AspNetUsers", Schema = "Users")]
    public class AspNetUsers : IdentityUser<string>
    {
        //
    }
}
