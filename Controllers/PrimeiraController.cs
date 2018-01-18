using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();

        //[HttpGet("{id}")] 
        [HttpGet] 
        public IEnumerable<Cidades> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}",Name="CidadeAtual")]
        public Cidades Get(int id){
            return dao.Listar().Where(x=>x.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cidades cidades){
            dao.Cadastro(cidades);
            return CreatedAtRoute("CidadeAtual", new {id=cidades.Id}, cidades);
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            dao.Excluir(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cidades cidades){
            dao.Atualizar(cidades);
            return CreatedAtRoute("CidadeAtual", new {id=cidades.Id}, cidades);
        }
    }
}