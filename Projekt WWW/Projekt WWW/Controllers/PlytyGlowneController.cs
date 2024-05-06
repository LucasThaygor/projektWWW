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
    public class PlytyGlowneController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PlytyGlowneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("plyty_glowne")]
        public JsonResult Get()
        {
            string query = @"select * from PlytyGlowne";
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
        [Route("plyty_glowne/{id}")]
        public JsonResult GetUser(int id)
        {
            string query = @"select * from PlytyGlowne where plyta_id=" + id;
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
        [Route("plyty_glowne")]
        public JsonResult Post([FromBody] PlytyGlowne plytyGlowne)
        {
            string query = @"INSERT INTO PlytyGlowne (plyta_nazwa, plyta_chipset, plyta_socket, plyta_ddr, plyta_slotyram, plyta_taktowanieram, plyta_maxram)
            VALUES(
            @plyta_nazwa,
            @plyta_chipset,
            @plyta_socket,
            @plyta_ddr,
            @plyta_slotyram,
            @plyta_taktowanieram,
            @plyta_maxram)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@plyta_nazwa", plytyGlowne.plyta_nazwa);
                    myCommand.Parameters.AddWithValue("@plyta_chipset", plytyGlowne.plyta_chipset);
                    myCommand.Parameters.AddWithValue("@plyta_socket", plytyGlowne.plyta_socket);
                    myCommand.Parameters.AddWithValue("@plyta_ddr", plytyGlowne.plyta_ddr);
                    myCommand.Parameters.AddWithValue("@plyta_slotyram", plytyGlowne.plyta_slotyram);
                    myCommand.Parameters.AddWithValue("@plyta_taktowanieram", plytyGlowne.plyta_taktowanieram);
                    myCommand.Parameters.AddWithValue("@plyta_maxram", plytyGlowne.plyta_maxram);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        [Route("plyty_glowne")]
        public JsonResult Put([FromBody] PlytyGlowne plytyGlowne)
        {
            string query = @"UPDATE PlytyGlowne SET 
            plyta_nazwa=@plyta_nazwa,
            plyta_chipset=@plyta_chipset,
            plyta_socket=@plyta_socket,
            plyta_ddr=@plyta_ddr,
            plyta_slotyram=@plytaslotyram,
            plyta_taktowanieram=@plyta_taktowanieram,
            plyta_maxram=@plyta_maxram
            WHERE plyta_id = @plyta_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@plyta_nazwa", plytyGlowne.plyta_nazwa);
                    myCommand.Parameters.AddWithValue("@plyta_chipset", plytyGlowne.plyta_chipset);
                    myCommand.Parameters.AddWithValue("@plyta_socket", plytyGlowne.plyta_socket);
                    myCommand.Parameters.AddWithValue("@plyta_ddr", plytyGlowne.plyta_ddr);
                    myCommand.Parameters.AddWithValue("@plyta_slotyram", plytyGlowne.plyta_slotyram);
                    myCommand.Parameters.AddWithValue("@plyta_taktowanieram", plytyGlowne.plyta_taktowanieram);
                    myCommand.Parameters.AddWithValue("@plyta_maxram", plytyGlowne.plyta_maxram);
                    myCommand.Parameters.AddWithValue("@plyta_id", plytyGlowne.plyta_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete]
        [Route("plyty_glowne/{id}")]
        public JsonResult DeleteUser(int id)
        {
            string query = @"DELETE FROM PlytyGlowne where plyta_id=@plyta_id";
            string sqlDataSource = _configuration.GetConnectionString("MySQL");
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@plyta_id", id);
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