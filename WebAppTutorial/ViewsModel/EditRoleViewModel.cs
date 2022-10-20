namespace WebAppTutorial.Views.Administration
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
