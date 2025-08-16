using CadastroAPI.Models;
using CadastroAPI.Repositories;
using CadastroAPI.Entities;
using CadastroAPI.Mappers;

namespace CadastroAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<PersonGetModel>> GetAllAsync()
        {
            var entities = await _personRepository.GetAllAsync();
            return entities.Select(e => e.ToGetModel());
        }
        public async Task<PersonGetModel?> GetByIdAsync(int id)
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity == null) return null;
            return entity.ToGetModel();
        }
        public async Task<PersonGetModel> CreateAsync(PersonCreateModel model)
        {
            var entity = model.ToEntity();
            var createdEntity = await _personRepository.CreateAsync(entity);
            return createdEntity.ToGetModel();
        }
        public async Task<PersonGetModel?> UpdateAsync(int id, PersonUpdateModel model)
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            model.MapUpdateModelToEntity(entity);

            var updated = await _personRepository.UpdateAsync(entity);
            return updated.ToGetModel();
        }
        public async Task<bool> DeleteAsync(int id) 
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            return await _personRepository.DeleteAsync(id);
        }
    }
}
