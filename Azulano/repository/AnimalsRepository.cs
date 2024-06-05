using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azulano.Data;
using Azulano.Models.Animals;
using Microsoft.EntityFrameworkCore;

namespace Azulano.repository
{
    public class AnimalsRepository
    {
        private readonly MapeamentoAnimaisMarinhosDBContext _dbContext;

        public AnimalsRepository(MapeamentoAnimaisMarinhosDBContext mapeamentoAnimaisMarinhosDBContext)
        {
            _dbContext = mapeamentoAnimaisMarinhosDBContext;
        }
        

        public async Task<AnimalsModel> Adicionar(AnimalsModel animalsModel)
         {
            try { 
                await _dbContext.Animais.AddAsync(animalsModel);
                await _dbContext.SaveChangesAsync();
                return animalsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AnimalsModel> BuscarPorId(int id)
        {
            return await _dbContext.Animais.FindAsync(id);
        }

        public async Task<List<AnimalsModel>> BuscarTodosAnimais()
        {
             return await _dbContext.Animais.ToListAsync();
        }

        internal async Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<AnimalsModel> AtualizarAnimal(AnimalsModel atualizarAnimalsModel, int id)
        {
            var novoAnimal = await _dbContext.Animais.FindAsync(id);

            if (novoAnimal == null)
                return null;

            novoAnimal.NomeCientifico = atualizarAnimalsModel.NomeCientifico;
            novoAnimal.NomeComum = atualizarAnimalsModel.NomeComum;
            novoAnimal.Descricao = atualizarAnimalsModel.Descricao;
            novoAnimal.Habitat = atualizarAnimalsModel.Habitat;

            await _dbContext.SaveChangesAsync();

            return novoAnimal;
        }

    }
}