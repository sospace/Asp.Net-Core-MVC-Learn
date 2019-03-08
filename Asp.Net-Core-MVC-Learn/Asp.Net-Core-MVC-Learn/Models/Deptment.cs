using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    public class Deptment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; } = 100;
        public List<Account> Accounts { get; set; }
    }
}
