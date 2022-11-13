using Microsoft.AspNetCore.Mvc;
using projetoProva.Models;

namespace projetoProva.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VideogameController : ControllerBase
    {
        private BDContexto contexto;
        
        public VideogameController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
        
        [HttpGet]
        public List<Videogame> Listar()
        {
            return contexto.Videogames.ToList();
        }

        [HttpGet]
        public List<Videogame> ListarPorFabricante(string fabricante)
        {
            return contexto.Videogames.ToList();
        }


        [HttpGet]
        public Videogame Visualizar(int id)
        {
            return contexto.Videogames.FirstOrDefault(p => p.Id == id);
        }


        [HttpPost]
        public string Cadastrar([FromBody]Videogame dados)
        {
            contexto.Add(dados);
            contexto.SaveChanges();
            return "Video game cadastrado com sucesso";
        }

        [HttpDelete]
        public string Excluir([FromBody]int id)
        {
            Videogame dados = contexto.Videogames.FirstOrDefault(p => p.Id == id);
            if (dados == null)
            {
                return "Não foi encontrado nenhum Videogame para o ID informado";
            }
            else
            {
                contexto.Remove(dados);
                contexto.SaveChanges();

                return "Videogame removido com sucesso!";
            }
        }
        
    }
}