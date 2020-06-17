using System;
using System.ComponentModel.DataAnnotations;

namespace assignment_5.Models
{
    public class Signup
    {
        public Signup(){}

        public Signup(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age; 
        }
        
     
        
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}