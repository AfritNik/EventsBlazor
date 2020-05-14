using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace NikEventBlazor.Shared.Entries
{
    public class NikEvent
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId {get;set;}
        public User Author {get;set;}
        public int MaxMembers {get;set;} = int.MaxValue;

        public List<EventMember> Members {get;set;} =new List<EventMember>();
    }
}
