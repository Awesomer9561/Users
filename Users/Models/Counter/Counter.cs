using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Models
{
    public class Counter
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Counter(int id, DateTime timeStamp)
        {
            Id = id;
            TimeStamp = timeStamp;
        }
    }
}
