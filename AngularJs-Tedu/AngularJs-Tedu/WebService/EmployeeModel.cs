using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJs_Tedu.WebService
{
    public class EmployeeModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Salary { set; get; }
        public string Gender { set; get; }
        public DateTime BirthDay { set; get; }

    }
}