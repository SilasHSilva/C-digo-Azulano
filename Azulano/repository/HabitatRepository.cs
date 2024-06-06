using Azulano.Data;
using Azulano.Models.Habitat;
using Microsoft.EntityFrameworkCore;

namespace Azulano.repository
{
    public class HabitatRepository
    {
        private readonly MapeamentoAnimaisMarinhosDBContext _dbContext;

        public HabitatRepository(MapeamentoAnimaisMarinhosDBContext mapeamentoAnimaisMarinhosDBContext)
        {
            _dbContext = mapeamentoAnimaisMarinhosDBContext;
        }
        public async Task<HabitatModel> ObterPorId(long Id)
        {
            return await _dbContext.Habitat.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<HabitatModel> Adicionar(HabitatModel habitatModel)
        {
            try
            {
                await _dbContext.Habitat.AddAsync(habitatModel);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return habitatModel;
        }

        public async Task<HabitatModel> BuscarPorId(int id)
        {
            var habitat = await _dbContext.Habitat.FirstOrDefaultAsync(x => x.Id == id);
            if (habitat == null)
            {
                throw new Exception($"Habitat com ID {id} não encontrado.");
            }
            return habitat;
        }

        public async Task<List<HabitatModel>> BuscarTodosHabitats()
        {
            return await _dbContext.Habitat.ToListAsync();
        }
        public async Task<bool> Apagar(int id)
        {
            HabitatModel habitatPorId = await BuscarPorId(id);

            if (habitatPorId == null)
            {
                throw new Exception($"Habitat para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Habitat.Remove(habitatPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<HabitatModel> Atualizar(HabitatModel habitatModel, int id)
        {
            HabitatModel habitatPorId = await BuscarPorId(id);

            if (habitatPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            habitatPorId.NameHabitat = habitatModel.NameHabitat;
            habitatPorId.DescricaoHabitat = habitatModel.DescricaoHabitat;
            habitatPorId.Localizacao = habitatModel.Localizacao;


            _dbContext.Habitat.Update(habitatPorId);
            await _dbContext.SaveChangesAsync();

            return habitatPorId;
        }

    }
}