using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AngularJs_Tedu.WebService
{
    /// <summary>
    /// Summary description for Employeee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Employeee : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetEmployees()
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            var conectionString = ConfigurationManager.ConnectionStrings["AngularJsBasic"].ConnectionString;
           
           using(var conection = new SqlConnection(conectionString))
            {
                SqlCommand command = new SqlCommand("select*from Employees", conection);
                conection.Open();
                SqlDataReader reader = command.ExecuteReader();
                EmployeeModel employee;
                while (reader.Read())
                {
                    employee = new EmployeeModel();
                    employee.Id = Int32.Parse(reader["Id"].ToString());
                    employee.Name = reader["Name"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Salary = Int32.Parse(reader["Salary"].ToString());
                    employee.BirthDay = DateTime.Parse(reader["BirthDay"].ToString());

                    listEmployee.Add(employee);
                }
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                Context.Response.Write(jsSerializer.Serialize(listEmployee));
            }
        }
    }
}
