
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        
        [HttpGet]
        public IEnumerable<Cidades> Get(){
            return cidade.Listar();
        }

    }
}