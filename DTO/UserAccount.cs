using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAccount
    {
        public int ID_User { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }    
        public string Role { get; set; }    
    }
}
