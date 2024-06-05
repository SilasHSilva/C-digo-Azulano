using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        internal async Task<HabitatModel> Adicionar(HabitatModel habitatModel)
        {
            throw new NotImplementedException();
        }

        internal async Task<HabitatModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<List<HabitatModel>> BuscarTodosHabitats()
        {
            throw new NotImplementedException();
        }
    }
}