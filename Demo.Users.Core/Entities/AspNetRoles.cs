using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Users.Core.Entities
{
    [Table("AspNetRoles", Schema = "Users")]
    public class AspNetRoles : IdentityRole<string>
    {
    }
}
