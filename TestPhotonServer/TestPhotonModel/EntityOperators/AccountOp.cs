using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhotonModel.CommonFunction;
using TestPhotonModel.Entities;

namespace TestPhotonModel.EntityOperators
{
    public static class AccountOp
    {
        public static void CreatAccout(string userName, string password)
        {
            Account account = new Account 
            {
                UserName=userName,
                PasswordMd5 = Md5Password.MD5Create(password),
                LastLoginin=DateTime.Now,
                Enable=true
            };
            using (var context = new EntityContext())
            {
                context.Accouts.Add(account);
                context.SaveChanges();
            }
        }
    }
}
