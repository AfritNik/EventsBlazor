using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NikEventBlazor.Shared.Entries
{
    public class User
    {
        public int Id {get;set;}
        [Required]
        public string Name {get; set;}
        public string LastName {get;set;}
        public string Nikname {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        public string Password {get; set;}

    }
}
