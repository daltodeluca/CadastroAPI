using CadastroAPI.Models;
using CadastroAPI.Repositories;
using CadastroAPI.Entities;
using CadastroAPI.Mappers;

namespace CadastroAPI.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<IEnumerable<PessoaGetModel>> GetAllAsync()
        {
            var entities = await _pessoaRepository.GetAllAsync();
            return entities.Select(e => e.ToGetModel());
        }
        public async Task<PessoaGetModel?> GetByIdAsync(int id)
        {
            var entity = await _pessoaRepository.GetByIdAsync(id);
            if (entity == null) return null;
            return entity.ToGetModel();
        }
        public async Task<PessoaGetModel> CreateAsync(PessoaCreateModel model)
        {
            var entity = model.ToEntity();
            var createdEntity = await _pessoaRepository.CreateAsync(entity);
            return createdEntity.ToGetModel();
        }
        public async Task<PessoaGetModel?> UpdateAsync(int id, PessoaUpdateModel model)
        {
            var entity = await _pessoaRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.Nome = model.Nome;
            entity.Sobrenome = model.Sobrenome;
            entity.Email = model.Email;
            entity.DataNascimento = model.DataNascimento;
            entity.Telefone = model.Telefone;

            var updated = await _pessoaRepository.UpdateAsync(entity);
            return updated.ToGetModel();
        }
        public async Task<bool> DeleteAsync(int id) 
        {
            var entity = await _pessoaRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            return await _pessoaRepository.DeleteAsync(id);
        }
    }
}
