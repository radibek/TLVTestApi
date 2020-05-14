using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace TATestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

     

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
           
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

       


           //// string sql = "SELECT * FROM cars";
           // using var cmd = new SqlCommand(sql, con);

           //// using SqlDataReader rdr = cmd.ExecuteReader();

           // while (rdr.Read())
           // {
           //     Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
           //             rdr.GetInt32(2));
           // }

        }

        //private void insertToDB()
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@id", "abc");
        //            command.Parameters.AddWithValue("@username", "abc");
        //            command.Parameters.AddWithValue("@password", "abc");
        //            command.Parameters.AddWithValue("@email", "abc");

        //            connection.Open();
        //            int result = command.ExecuteNonQuery();

        //            // Check Error
        //            if (result < 0)
        //                Console.WriteLine("Error inserting data into Database!");
        //        }
        //    }
        //}



    }
