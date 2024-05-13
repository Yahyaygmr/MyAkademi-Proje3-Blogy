namespace Blogy.WebUI.Areas.Writer.Models
{
    public class UpdateWriterProfileViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
