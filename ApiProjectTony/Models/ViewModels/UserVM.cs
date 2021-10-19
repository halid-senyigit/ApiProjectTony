namespace ApiProjectTony.Models.ViewModels
{
    public class UserVM
    {
        public string Gender {  get; set; }

        // Mapped => (name.first) + (name.last)
        public string Name {  get; set; }
        public string Email {  get; set; }
    }
}
