using System;

namespace TestPhotonModel.Entities
{
    /// <summary>
    ///     账号
    /// </summary>
    public class Account
    {
        /// <summary>
        ///     主键
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        ///     MD5保存的密码
        /// </summary>
        public string PasswordMd5 { set; get; }

        /// <summary>
        ///     最后登录时间
        /// </summary>
        public DateTime LastLoginin { set; get; }

        /// <summary>
        ///     是否可用
        /// </summary>
        public bool Enable { set; get; }
    }
}