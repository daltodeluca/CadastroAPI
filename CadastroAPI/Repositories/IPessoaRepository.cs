namespace CadastroAPI.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Models.Pessoa>> GetAllAsync();
        Task<Models.Pessoa> GetByIdAsync(int id);
        Task<Models.Pessoa> CreateAsync(Models.Pessoa pessoa);
        Task<Models.Pessoa> UpdateAsync(Models.Pessoa pessoa);
        Task<bool> DeleteAsync(int id);
    }
}
