using System.ComponentModel.DataAnnotations;


namespace Client.Models
{
    public class PersonData
    {   [Required(ErrorMessage="Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Phone")]
        public string Phone { get; set; }
 
    }
}
