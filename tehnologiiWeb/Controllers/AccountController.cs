using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.Web.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        void connectionString()
        {
            con.ConnectionString = "data source = DESKTOP-ALJNJQU; Database=TehnologiiWeb; integrated security = SSPI";
        }

        public IActionResult Verify(Account account)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from dbo.accounts where username='"+account.username+"' and password='"+account.password+"'";
            dr = com.ExecuteReader();

            if(dr.Read())
            { 
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }


            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return View();
        }

        public IActionResult Logout(string username, string password)
        {
            return View();
        }

        public IActionResult Register(string username, string password)
        {
            return View();
        }
    }
}
