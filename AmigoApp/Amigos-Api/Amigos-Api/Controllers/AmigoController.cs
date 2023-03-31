using Amigos_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static Amigos_Api.CRUD.Crud;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amigos_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoController : ControllerBase {


        const string connectionString =
            "Data Source=amigos-tp3.database.windows.net;Initial Catalog=AmigoDB_tp3;User ID=Nome;Password=Password;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = new SqlConnection(connectionString);

        // GET: api/<AmigoController>
        [HttpGet]
        public List<Amigo> ConsultarTodos() {
            return ConsultarAmigos(conn);
        }

        // GET api/<AmigoController>/5
        [HttpGet("{id}")]
        public Amigo Consultar(int id) {
            return ConsultarAmigo(conn, id);
        }

        // POST api/<AmigoController>
        [HttpPost]
        public string Incluir(Amigo amigo) {
            int cont = InserirAmigo(conn, amigo);
            if (cont > 0) {
                return "Amigo Inserido";
            } else {
                return "Erro na inclusão";
            }
        }

        // PUT api/<AmigoController>/5
        [HttpPut("{id}")]
        public string Alterar(Amigo amigo) {
            int cont = AlterarAmigo(conn, amigo);
            if (cont > 0) {
                return "Amigo Alterado";
            } else {
                return "Erro na Alteração";
            }
        }

        // DELETE api/<AmigoController>/5
        [HttpDelete("{id}")]
        public string Ecluir(int id) {
            int cont = ExcluirAmigo(conn, id);
            if (cont > 0) {
                return "Amigo Excluido";
            } else {
                return "Erro na Exclusão";
            }
        }
    }
}
