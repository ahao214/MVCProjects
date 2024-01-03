using System;

namespace BeautySalon.Models.TableModel
{
    public class UserAdmin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string RealName { get; set; }
        public string Telphone { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public decimal Salary { get; set; }
        public int UserStatus { get; set; }

        public string ImgCode { get; set; }

        public short IsDelete { get; set; }

    }
}
