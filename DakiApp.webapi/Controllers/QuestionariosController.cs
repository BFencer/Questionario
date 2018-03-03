using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DakiApp.domain.Contracts;
using DakiApp.domain.Entities;

namespace DakiApp.webapi.Controllers
{
    [Route("api/[controller]")]
    public class QuestionariosController: Controller
    {
        private readonly IBaseRepository<QuestionariosDomain> _repo;

        public QuestionariosController(IBaseRepository<QuestionariosDomain> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repo.Listar());
        }

        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_repo.BuscarPorId(id));
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            var questionarios = _repo.BuscarPorId(id);
            return Ok(_repo.Deletar(questionarios));
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]QuestionariosDomain Questionarios)
        {
            return Ok(_repo.Inserir(Questionarios));
        }

        [HttpPut ("{id}")]
        public IActionResult Autalizar(int id)
        {
            var questionarios = _repo.BuscarPorId(id);
            return Ok(_repo.Atualizar(questionarios));
        }


        
    }
}