using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "姓名")]//设置字典显示名称
        public string Name { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
