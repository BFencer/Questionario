using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DakiApp.domain.Contracts;
using DakiApp.domain.Entities;
using DakiApp.repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DakiApp.webapi.Controllers
{
    [Route("api/[controller]")]
    public class QuestionariosController: Controller
    {
        private readonly IBaseRepository<QuestionariosDomain> _repo;

        private readonly DakiAppContext _context;

        public QuestionariosController(IBaseRepository<QuestionariosDomain> repo, DakiAppContext context)
        {
            _repo = repo;
            _context = context;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repo.Listar());
        }

        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // var questionario =  _context
            //     .Questionarios
            //     .Include(d => d.QuestionarioPerguntas)
            //     .ThenInclude(d => d.Pergunta.Alternativas)
            //     .FirstOrDefault(d => d.id == id);
            
            // var projection = new {
            //     questionario.id,
            //     questionario.Nome,
            //     perguntas = questionario.QuestionarioPerguntas.Select(d => new {
            //         d.Pergunta.id,
            //         d.Pergunta.DataCriacao,
            //         d.Pergunta.Enunciado,
            //         Alternativas = d.Pergunta.Alternativas.Select(g => new {
            //             g.id,
            //             g.Conteudo,
            //             g.DataCriacao,
            //         }).ToArray(),
            //     }).ToArray()
            // };
            // return Ok(projection);


            var includes = new string[]{ "QuestionarioPerguntas", "QuestionarioPerguntas.Pergunta.Alternativas" };

            return Ok(_repo.BuscarPorId(id,includes));
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