using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public string AvatarPath {  get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }


    }
}
