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
    public class RAMController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RAMController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("ram")]
        public JsonResult Get()
        {
            string query = @"select * from RAM";
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
        [Route("ram/{id}")]
        public JsonResult GetUser(int id)
        {
            string query = @"select * from RAM where ram_id=" + id;
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
        [Route("ram")]
        public JsonResult Post([FromBody] RAM rAM)
        {
            string query = @"INSERT INTO RAM (ram_nazwa, ram_ddr, ram_taktowanie, ram_slotyram, ram_rozmiar)
            VALUES(
            @ram_nazwa, 
            @ram_ddr, 
            @ram_taktowanie, 
            @ram_slotyram, 
            @ram_rozmiar)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ram_nazwa", rAM.ram_nazwa);
                    myCommand.Parameters.AddWithValue("@ram_ddr", rAM.ram_ddr);
                    myCommand.Parameters.AddWithValue("@ram_taktowanie", rAM.ram_taktowanie);
                    myCommand.Parameters.AddWithValue("@ram_slotyram", rAM.ram_slotyram);
                    myCommand.Parameters.AddWithValue("@ram_rozmiar", rAM.ram_rozmiar);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        [Route("ram")]
        public JsonResult Put([FromBody] RAM rAM)
        {
            string query = @"UPDATE RAM SET 
            ram_ddr=@ram_ddr, 
            ram_taktowanie=@ram_taktowanie, 
            ram_slotyram@ram_slotyram, 
            ram_rozmiar=@ram_rozmiar
            WHERE ram_id = @ram_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ram_nazwa", rAM.ram_nazwa);
                    myCommand.Parameters.AddWithValue("@ram_ddr", rAM.ram_ddr);
                    myCommand.Parameters.AddWithValue("@ram_taktowanie", rAM.ram_taktowanie);
                    myCommand.Parameters.AddWithValue("@ram_slotyram", rAM.ram_slotyram);
                    myCommand.Parameters.AddWithValue("@ram_rozmiar", rAM.ram_rozmiar);
                    myCommand.Parameters.AddWithValue("@ram_id", rAM.ram_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete]
        [Route("ram/{id}")]
        public JsonResult DeleteUser(int id)
        {
            string query = @"DELETE FROM RAM where ram_id=@ram_id";
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ram_id", id);
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