using System;
using System.Data.Entity.Migrations;
using System.Linq;
using TestPhotonModel.CommonFunction;
using TestPhotonModel.Entities;

namespace TestPhotonModel.EntityOperators
{
    public static class AccountOp
    {
        /// <summary>
        ///     根据账号ID返回对应的账号
        /// </summary>
        /// <param name="accountId">账号ID</param>
        /// <returns>账号对象</returns>
        public static Account GetAccount(int accountId)
        {
            Account account;
            using (var context = new EntityContext())
            {
                account = (from a in context.Accounts
                           where a.Id == accountId
                           select a).FirstOrDefault();
            }
            return account;
        }

        /// <summary>
        ///     根据用户名返回对应的账号
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>账号对象，找不到时为null</returns>
        public static Account GetAccount(string username)
        {
            Account account;
            using (var context = new EntityContext())
            {
                account = (from a in context.Accounts
                           where a.UserName == username
                           select a).FirstOrDefault();
            }
            return account;
        }

        /// <summary>
        ///     验证账号密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否验证通过</returns>
        public static bool VerifyPassword(string username, string password)
        {
            var account = GetAccount(username);
            if (account == null)
            {
                return false;
            }
            return account.PasswordMd5 == Md5Password.MD5Create(password);
        }

        /// <summary>
        ///     更新（有相同ID时）或添加（无相同ID时）账号
        /// </summary>
        /// <param name="account">账号对象</param>
        /// <returns>0失败，大于0成功</returns>
        public static int UpdateOrAdd(Account account)
        {
            if (account == null)
            {
                return 0;
            }
            using (var context = new EntityContext())
            {
                context.Accounts.AddOrUpdate(account);
                return context.SaveChanges();
            }
        }

        /// <summary>
        ///     启用或者禁用账号
        /// </summary>
        /// <param name="account">账号对象</param>
        /// <param name="isEnable">是否启用</param>
        public static void SetEnable(Account account, bool isEnable)
        {
            account.Enable = isEnable;
            UpdateOrAdd(account);
        }

        /// <summary>
        ///     创建账号
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>影响行数 </returns>
        public static int CreatAccout(string userName, string password)
        {
            //检查用户名是否已经存在
            if (GetAccount(userName) != null)
            {
                return 0;
            }
            var account = new Account
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

        /// <summary>
        ///     删除账号
        /// </summary>
        /// <param name="accountId">账号Id</param>
        /// <returns>0失败，大于0成功</returns>
        public static int DeleteAccount(int accountId)
        {
            using (var context = new EntityContext())
            {
                Account account = (from a in context.Accounts
                                   where a.Id == accountId
                                   select a).FirstOrDefault();
                if (account == null)
                {
                    return 0;
                }
                context.Accounts.Remove(account);
                return context.SaveChanges();
            }
        }
    }
}