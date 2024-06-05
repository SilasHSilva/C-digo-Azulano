using Azulano.Models.Animals;
using Azulano.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Azulano.Controllers.Animals
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
        {
        private readonly AnimalsRepository _animalsRepository;
        private readonly HabitatRepository _habitatRepository;

        public AnimalsController(AnimalsRepository animalsRepository, HabitatRepository habitatRepository)
        {
            _animalsRepository = animalsRepository;
            _habitatRepository = habitatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalsModel>>> BuscarAnimais()
        {
            List<AnimalsModel> animais = await _animalsRepository.BuscarTodosAnimais();
            return Ok(animais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalsModel>> BuscarPorId(int id)
        {
            AnimalsModel animal = await _animalsRepository.BuscarPorId(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalsModel>> Cadastrar([FromBody] AnimalsModel animalsModelI)
        {
            try
            {
                if (animalsModelI == null)
                    return BadRequest();

                var habitatExistente = await _habitatRepository.ObterPorId(animalsModelI.Id);
                if (habitatExistente == null)
                    return BadRequest("O habitat fornecido não existe.");

                var animalsModel = new AnimalsModel
                {
                    NomeCientifico = animalsModelI.NomeCientifico,
                    NomeComum = animalsModelI.NomeComum,
                    Descricao = animalsModelI.Descricao,
                    HabitatId = animalsModelI.HabitatId
                };

                AnimalsModel animal = await _animalsRepository.Adicionar(animalsModel);

                return CreatedAtAction(nameof(BuscarPorId), new { id = animal.Id }, animal);
            }
            catch(Exception ex) {
                if (ex.InnerException is DbUpdateException dbUpdateException)
                {
                    var sqlException = dbUpdateException.GetBaseException() as SqlException;
                    if (sqlException != null)
                    {
                        var number = sqlException.Number;
                        var message = sqlException.Message;

                        return BadRequest($"Erro ao salvar as alterações no banco de dados: {message}");
                    }
                }
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnimalsModel>> Atualizar(int id, [FromBody] AnimalsModel AtualizarAnimalsModel)
        {
            if (AtualizarAnimalsModel == null || AtualizarAnimalsModel.Id != id)
                return BadRequest();

            AnimalsModel animalAtualizado = await _animalsRepository.AtualizarAnimal(AtualizarAnimalsModel, id);
            if (animalAtualizado == null)
            {
                return NotFound();
            }
            return Ok(animalAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _animalsRepository.Apagar(id);
            if (!apagado)
                return NotFound();
            
            return Ok(apagado);
        }
    }
}
