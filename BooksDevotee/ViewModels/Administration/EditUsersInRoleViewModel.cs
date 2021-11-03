using System.Collections.Generic;

namespace BooksDevotee.ViewModels.Administration
{
    public class EditUsersInRoleViewModel
    {
        public string RoleId { get; set; }
        public List<UserRoleViewModel> UsersInRole { get; set; }
    }
}
