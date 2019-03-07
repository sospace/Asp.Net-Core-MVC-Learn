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
                if (content.Account.Any())
                    return;
                content.Account.AddRange(new Account()
                {
                    Name = "test",
                    Email = "1@1.com",
                    UserName = "test",
                    BirthDay = new DateTime(1987, 2, 2)
                }, new Account()
                {
                    Name = "test2",
                    Email = "2@2.com",
                    UserName = "test2",
                    BirthDay = new DateTime(1987, 2, 3)
                });
                content.SaveChanges();
            }
        }
    }
}
