using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhotonModel.CommonFunction;
using TestPhotonModel.Entities;
using System.Data.SqlClient;

namespace TestPhotonModel.EntityOperators
{
    public static class AccountOp
    {
        /// <summary>
        /// 根据账号ID返回对应的账号
        /// </summary>
        /// <param name="accountId">账号ID</param>
        /// <returns>账号对象</returns>
        public static Account GetAccount(int accountId)
        {
            Account account = null;
            using (var context = new EntityContext())
            {
                account = (from a in context.Accounts
                                   where a.Id == accountId
                                   select a).FirstOrDefault();

            }
            return account;
        }

        /// <summary>
        /// 创建账号
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>影响行数 </returns>
        public static int CreatAccout(string userName, string password)
        {
            Account account = new Account
            {
                UserName = userName,
                PasswordMd5 = Md5Password.MD5Create(password),
                LastLoginin = DateTime.Now,
                Enable = true
            };
            using (var context = new EntityContext())
            {
                context.Accounts.Add(account);
                return context.SaveChanges();
            }
        }



        public static void SetDisable(int accountId)
        {
            using (var context = new EntityContext())
            {
                Account account = (from a in context.Accounts
                                   where a.Id == accountId
                                   select a).FirstOrDefault();
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }
    }
}
