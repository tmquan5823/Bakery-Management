using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DTO
{
    public class Staff
    {
        public string ID_Staff { get; set; }
        public string Staff_Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string CCCD { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Shift { get; set; }
        public int Salary { get; set; } 
        public int ID_User { get; set; }  
        public byte[] urlImage { get; set; }    
    }
}
