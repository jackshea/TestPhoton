using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestPhotonModel.CommonFunction
{
    public static class Md5Password
    {
        public static string MD5Create(string password)
        {
            MD5 md5 = MD5.Create();
            //密码加上!password!前缀,防止MD5数据库反查
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes("!password!" + password));
            return BitConverter.ToString(s).Replace("-", "");
        }
    }
}
