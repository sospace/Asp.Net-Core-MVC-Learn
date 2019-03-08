using Asp.Net_Core_MVC_Learn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    public class SeedData
    {
        /// <summary>
        /// 如果服务开始前 没有数据，在这里添加初始数据
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var content = new ApplicationDbContext(serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (content.Deptment.Any() || content.Account.Any())
                    return;
                for (int i = 1; i <= 3; i++)
                {
                    var dept = new Deptment()
                    {
                        Name = "部门" + i,
                        Accounts = new List<Account>()
                    };

                    for (int k = 1; k <= i; k++)
                    {
                        dept.Accounts.Add(new Account()
                        {
                            Name = "用户" + i + k,
                            UserName = "Test" + i + k
                        });
                    }
                    content.Deptment.AddRange(dept);
                }
                content.SaveChanges();
            }
        }
    }
}
