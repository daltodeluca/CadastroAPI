using CadastroAPI.Models;
using CadastroAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await _pessoaService.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _pessoaService.GetByIdAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Pessoa não pode ser nula");
            }
            var createdPessoa = await _pessoaService.CreateAsync(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = createdPessoa.Id }, createdPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null || pessoa.Id != id)
            {
                return BadRequest("Dados da pessoa invalidos.");
            }
            var updatedPessoa = await _pessoaService.UpdateAsync(pessoa);
            if (updatedPessoa == null)
            {
                return NotFound();
            }
            return Ok(updatedPessoa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pessoaService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
