﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPhotonModel.EntityOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhotonModel.Entities;

namespace TestPhotonModel.EntityOperators.Tests
{
    [TestClass()]
    public class AccountOpTests
    {
        [TestMethod()]
        public void GetAccountTest()
        {
            Assert.IsNull(AccountOp.GetAccount(30000));
            Assert.AreEqual(AccountOp.GetAccount(1).UserName, "xiezaikui");
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Account account = new Account
            {
                Id = 2,
                Enable = true,
                LastLoginin = DateTime.Now,
                UserName = "jackshea",
                PasswordMd5 = CommonFunction.Md5Password.MD5Create("xzkk5669")
            };
            Assert.AreEqual(AccountOp.UpdateOrAdd(account), 1);
            Assert.IsNotNull(AccountOp.GetAccount("jackshea"));
        }

        [TestMethod()]
        public void VerifyPasswordTest()
        {
            Account account = AccountOp.GetAccount("test1");
            if (account != null)
            {
                AccountOp.DeleteAccount(account.Id);
            }
            Assert.AreEqual(AccountOp.CreatAccout("test1", "password"), 1);
            account = AccountOp.GetAccount("test1");
            AccountOp.SetEnable(account, false);
            Assert.IsFalse(account.Enable);
            account = AccountOp.GetAccount("test1");
            Assert.IsFalse(account.Enable);
            Assert.IsNotNull(account);
            Assert.IsTrue(AccountOp.VerifyPassword("test1", "password"));
            Assert.IsTrue(AccountOp.DeleteAccount(account.Id) >= 1);
        }
    }
}