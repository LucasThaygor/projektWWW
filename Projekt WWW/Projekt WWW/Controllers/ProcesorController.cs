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
    public class ProcesorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProcesorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("procesory")]
        public JsonResult Get()
        {
            string query = @"select * from Procesory";
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
        [Route("procesory/{id}")]
        public JsonResult GetUser(int id)
        {
            string query = @"select * from Procesory where procesor_id=" + id;
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
        [Route("procesory")]
        public JsonResult Post([FromBody] Procesory procesory)
        {
            string query = @"INSERT INTO Procesory (procesor_nazwa, procesor_socket, procesor_ddr, procesor_grafika, procesor_taktowanie)
            VALUES(
            @procesor_nazwa,
            @procesor_socket,
            @procesor_ddr,
            @procesor_grafika,
            @procesor_taktowanie)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@procesor_nazwa", procesory.procesor_nazwa);
                    myCommand.Parameters.AddWithValue("@procesor_socket", procesory.procesor_socket);
                    myCommand.Parameters.AddWithValue("@procesor_ddr", procesory.procesor_ddr);
                    myCommand.Parameters.AddWithValue("@procesor_grafika", procesory.procesor_grafika);
                    myCommand.Parameters.AddWithValue("@procesor_taktowanie", procesory.procesor_taktowanie);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        [Route("procesory")]
        public JsonResult Put([FromBody] Procesory procesory)
        {
            string query = @"UPDATE Procesory SET 
            procesor_nazwa=@procesor_nazwa,
            procesor_socket=@procesor_socket,
            procesor_ddr=@procesor_ddr,
            procesor_grafika=@procesor_grafika,
            procesor_taktowanie=@procesor_taktowanie
            WHERE procesor_id = @procesor_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@procesor_nazwa", procesory.procesor_nazwa);
                    myCommand.Parameters.AddWithValue("@procesor_socket", procesory.procesor_socket);
                    myCommand.Parameters.AddWithValue("@procesor_ddr", procesory.procesor_ddr);
                    myCommand.Parameters.AddWithValue("@procesor_grafika", procesory.procesor_grafika);
                    myCommand.Parameters.AddWithValue("@procesor_taktowanie", procesory.procesor_taktowanie);
                    myCommand.Parameters.AddWithValue("@procesor_id", procesory.procesor_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete]
        [Route("procesory/{id}")]
        public JsonResult DeleteUser(int id)
        {
            string query = @"DELETE FROM Procesory where procesor_id=@procesor_id";
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@procesor_id", id);
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