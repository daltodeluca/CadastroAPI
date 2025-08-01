using CadastroAPI.Models;
using CadastroAPI.Repositories;

namespace CadastroAPI.Services
{
    public class PessoaService: IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _pessoaRepository.GetAllAsync();
        }
        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _pessoaRepository.GetByIdAsync(id);
        }
        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.CreateAsync(pessoa);
        }
        public async Task<Pessoa> UpdateAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.UpdateAsync(pessoa);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _pessoaRepository.DeleteAsync(id);
        }
    }
}
