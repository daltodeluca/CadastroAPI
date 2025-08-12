using CadastroAPI.Models;
using CadastroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] PessoaCreateModel model)
        {
            var createdPessoa = await _pessoaService.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = createdPessoa.Id }, createdPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [Required][FromBody] PessoaUpdateModel model)
        {
            var updatedPessoa = await _pessoaService.UpdateAsync(id, model);
            return Ok(updatedPessoa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pessoaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
