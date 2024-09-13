using api_noticia.Models;
using api_noticia.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_noticia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutor autorRepos;

        public AutorController(IAutor repository)
        {
            autorRepos = repository;
        }

        [HttpGet]
        public IActionResult GetTodas()
        {
            try
            {
                var lista = autorRepos.GetAll();
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
                var result = autorRepos.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(Autor autor)
        {
            try
            {
                var result = autorRepos.InsertAutor(autor);
                return Ok("Autor cadastro com sucesso," + result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(Autor autor)
        {
            try
            {
                var result = autorRepos.UpAutor(autor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAutor(int id)
        {
            try
            {
                var result = autorRepos.DeleteAutor(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
