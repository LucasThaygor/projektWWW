using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Projekt_WWW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace MySqlWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class KartyGraficzneController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KartyGraficzneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("karty_graficzne")]
        public JsonResult Get()
        {
            string query = @"select * from KartyGraficzne";
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpGet]
        [Route("karty_graficzne/{id}")]
        public JsonResult GetUser(int id)
        {
            string query = @"select * from KartyGraficzne where karta_id=" + id;
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        [Route("karty_graficzne")]
        public JsonResult Post([FromBody] KartyGraficzne kartyGraficzne)
        {
            string query = @"INSERT INTO KartyGraficzne (karta_nazwa, karta_grafika, karta_pamiec)
            VALUES(
            @karta_nazwa,
            @karta_grafika, 
            @karta_pamiec)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@karta_nazwa", kartyGraficzne.karta_nazwa );
                    myCommand.Parameters.AddWithValue("@karta_grafika", kartyGraficzne.karta_grafika);
                    myCommand.Parameters.AddWithValue("@karta_pamiec", kartyGraficzne.karta_pamiec);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        [Route("karty_graficzne")]
        public JsonResult Put([FromBody] KartyGraficzne kartyGraficzne)
        {
            string query = @"UPDATE KartyGraficzne SET 
            karta_nazwa=@karta_nazwa,
            karta_grafika=@karta_grafika, 
            karta_grafika=@karta_pamiec
            WHERE karta_id = @karta_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@karta_nazwa", kartyGraficzne.karta_nazwa);
                    myCommand.Parameters.AddWithValue("@karta_grafika", kartyGraficzne.karta_grafika);
                    myCommand.Parameters.AddWithValue("@karta_pamiec", kartyGraficzne.karta_pamiec);
                    myCommand.Parameters.AddWithValue("@karta_id", kartyGraficzne.karta_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete]
        [Route("karty_graficzne/{id}")]
        public JsonResult DeleteUser(int id)
        {
            string query = @"DELETE FROM KartyGraficzne where karta_id=@karta_id";
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@karta_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
