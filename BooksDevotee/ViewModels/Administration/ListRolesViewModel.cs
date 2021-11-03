using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BooksDevotee.ViewModels.Administration
{
    public class ListRolesViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
