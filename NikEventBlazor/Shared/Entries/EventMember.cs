using System;
using System.Collections.Generic;
using System.Text;

namespace NikEventBlazor.Shared.Entries
{
    public class EventMember
    {
        public int EventId {get;set;}
        public int MemberId {get;set;}
        public NikEvent Event {get; set;}
        public User Member {get;set;}
    }
}
