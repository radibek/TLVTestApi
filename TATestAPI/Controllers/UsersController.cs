using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TATestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly string _connectionString;

        public UsersController()
        {
            _connectionString = @"Data Source=M2039955-W7\SQL2014C;Initial Catalog=RADI_DB;Integrated Security=False;User ID=RADI_DB;Password=RADI_DB";
        }

        
        [HttpGet]
        public List<User> Get()
        {
            List<User> users = readFromDB();

            return users;
        }


        private List<User> readFromDB()
        {
            List<User> list = new List<User>();

            try
            {


                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    String query = "SELECT * FROM Users";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                User user = new User();
                                user.Id = rdr.GetInt32(0);
                                user.Name = rdr.GetString(1);
                                list.Add(user);
                                Console.WriteLine("{0} {1}", user.Id, user.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                User user = new User();
                user.Id = 1;
                user.Name = "Test";

                list.Add(user);
                return list;
            }
           

            return list;
        }
    }


    public class User
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
