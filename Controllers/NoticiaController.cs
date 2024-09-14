using api_noticia.Models;
using api_noticia.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_noticia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticia NoticiaRepos;

        public NoticiaController(INoticia repository)
        {
            NoticiaRepos = repository;
        }

        [HttpGet]
        public IActionResult GetTodas()
        {
            try
            {
                var lista = NoticiaRepos.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var result = NoticiaRepos.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(Noticia noticia)
        {
            try
            {
                var result = NoticiaRepos.NewNoticia(noticia);
                return Ok("Noticia cadastrada com sucesso, " + result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteNot(int id)
        {
            try
            {
                var result = NoticiaRepos.DeleteNoticia(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Alterar(Noticia noticia)
        {
            try
            {
                var result = NoticiaRepos.UpNoticia(noticia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
