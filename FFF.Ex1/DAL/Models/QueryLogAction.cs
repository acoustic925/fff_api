using System;
using System.Collections.Generic;

namespace FFF.Ex1.DAL.Models
{
    public partial class QueryLogAction
    {
        public int Id { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Action { get; set; }
        public string UserIp { get; set; }
    }
}
