using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegestrationController : ControllerBase
    {
 
        private readonly IConfiguration _configuration;

        public RegestrationController( IConfiguration configuration)
        {

            _configuration = configuration;

        }

        [HttpPost]
        [Route("regestraion")]

        public string regestration (Regestration regestration)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            SqlCommand cmd =new SqlCommand("insert into Regestration(UserName,Email,Password,IsActive) VALUES('"+regestration.UserName + 

                "','"+regestration.Email + 

                "','"+regestration.Password +
                
                "','"+regestration.IsActive + "')", con);
            con.Open();
            int i =cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {

                return "Data Inserted";

            }
            else
            {
                return "Error";

            } 


            

        }




        [HttpPost]
        [Route("login")]

         
        public string login(Regestration regestration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            
            SqlDataAdapter da=new SqlDataAdapter("select * from Regestration Where Email = '"+regestration.Email +"' And Password = '" 
                +regestration.Password+"' And IsActive = 1  ",con);

            DataTable dt= new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)   
            {
                return "Valid User";


            }
           else {
                return "Invalid User";
            
            }
        }
    }
}
