using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using PersonalInformationAPI.Model;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        // GET: api/<PersonController>
        [HttpGet]
        public List<Person> Get()
        {
            List<Person> list = new List<Person>();
            string connectionString = "Server=localhost;Port=3306;Database=personalinformation;Uid=root;Pwd=20150601;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Person",conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Person()
                        {
                            personID = Convert.ToInt32(reader["personID"]),
                            firstName = reader["firstName"].ToString(),
                            lastName = reader["lastName"].ToString(),
                            address = reader["address"].ToString(),
                            gender = reader["gender"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person newPerson = null;
            string connectionString = "Server=localhost;Port=3306;Database=personalinformation;Uid=root;Pwd=20150601;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from Person where personID = '{id}'", conn);
                using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read()) {
                        newPerson = new Person(
                            (int)reader["PersonID"]
                            , reader["firstName"].ToString()
                            , reader["lastName"].ToString()
                            , reader["address"].ToString()
                            , reader["gender"].ToString()
                            );
                    }
                }
            }
            return newPerson;
        }

        // POST api/<PersonController>
        [HttpPost]
        public string Post([FromBody] Person person)
        {
            //Random rnd = new Random();
            //person.personID = rnd.Next(0,100);
            string connectionString = "Server=localhost;Port=3306;Database=personalinformation;Uid=root;Pwd=20150601;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into person values('{person.personID}','{person.firstName}','{person.lastName}','{person.address}','{person.gender}')", conn);
                int changes = cmd.ExecuteNonQuery();
                if (changes > 0)
                {
                    return "insert complete";
                }
                else
                {
                    return "there's something wrong";
                }
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Person modifiedPerson)
        {
            string connectionString = "Server=localhost;Port=3306;Database=personalinformation;Uid=root;Pwd=20150601;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"update person set firstName = '{modifiedPerson.firstName}',lastName = '{modifiedPerson.lastName}',address='{modifiedPerson.address}',gender = '{modifiedPerson.gender}' where  personID = '{id}'", conn);
                int changes = cmd.ExecuteNonQuery();
                if (changes > 0)
                {
                    return "update complete";
                }
                else
                {
                    return "there's something wrong";
                }
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string connectionString = "Server=localhost;Port=3306;Database=personalinformation;Uid=root;Pwd=20150601;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from person where personID = " + id, conn);
                int changes = cmd.ExecuteNonQuery();
                if(changes > 0)
                {
                    return "delete complete";
                }
                else
                {
                    return "can't find the item in db";
                }
            }
            
        }
    }
}
