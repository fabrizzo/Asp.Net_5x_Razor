using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApplication2.Data
{
    public class UserForecastService
    {
        public List<UserForecast> GetForecastAsync()
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
            using (var connection = new SqlConnection(connString))
            {
                var sql = "select * from users";
                var users = connection.Query(sql);
                List<UserForecast> item = new List<UserForecast>();
                foreach (var user in users)
                {
                    item.Add(new UserForecast() { PersonID = user.PersonID,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Address = user.Address,
                    City = user.City
                });


                }
                return item;
            }
        }
    }
}

