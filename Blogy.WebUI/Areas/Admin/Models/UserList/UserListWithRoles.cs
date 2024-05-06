namespace Blogy.WebUI.Areas.Admin.Models.UserList
{
    public class UserListWithRoles
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> Roles { get; set; }
    }
}
