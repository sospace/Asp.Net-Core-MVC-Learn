using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    public class ViewAccount
    {
        public List<Account> Accounts;
        public SelectList Depts;
        public string Str { get; set; }
        public int DeptId { get; set; }
    }
}
