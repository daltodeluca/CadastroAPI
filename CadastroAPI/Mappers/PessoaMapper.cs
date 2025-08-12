using CadastroAPI.Entities;
using CadastroAPI.Models;

namespace CadastroAPI.Mappers
{
    public static class PessoaMapper
    {
        public static PessoaEntity ToEntity(this PessoaCreateModel model)
        {
            return new PessoaEntity
            {
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Email = model.Email,
                DataNascimento = model.DataNascimento,
                Telefone = model.Telefone
            };
        }
        public static void MapUpdateModelToEntity(this PessoaUpdateModel model, PessoaEntity entity)
        {
            entity.Nome = model.Nome;
            entity.Sobrenome = model.Sobrenome;
            entity.Email = model.Email;
            entity.DataNascimento = model.DataNascimento;
            entity.Telefone = model.Telefone;
        }
        public static PessoaGetModel ToGetModel(this PessoaEntity entity)
        {
            return new PessoaGetModel
            (
                entity.Id,
                entity.Nome,
                entity.Sobrenome,
                entity.Email,
                entity.DataNascimento,
                entity.Telefone,
                entity.DataCriacao
            );
        }
    }
}
