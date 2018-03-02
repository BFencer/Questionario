using Microsoft.AspNetCore.Mvc;
using DakiApp.domain.Contracts;
using DakiApp.domain.Entities;

namespace DakiApp.webapi.Controllers
{
    [Route("api/[controller]")]
    public class QuestionarioController : Controller
    {
        private IBaseRepository<QuestionarioDomain> _questionarioRepository;

        public QuestionarioController(IBaseRepository<QuestionarioDomain> questionarioRepository)
        {
            _questionarioRepository = questionarioRepository;
        }

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_questionarioRepository.Listar(new string[]{"ProdutosQuestionario"}));
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var questionario = _questionarioRepository.BuscarPorId(id);
            if(questionario != null) 
                return Ok(questionario);
            else
                return NotFound();
        }
        
    }
}