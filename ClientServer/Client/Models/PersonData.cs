using System.ComponentModel.DataAnnotations;


namespace Client.Models
{   //И хотя я здесь реализовываю проверку модели, она здесь не нужна. Поскольку данные мы вытаскиваем с запроса.
    public class PersonData
    {   [Required(ErrorMessage="Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Phone")]
        public string Phone { get; set; }
 
    }
}
