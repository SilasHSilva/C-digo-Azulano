using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azulano.Models.Habitat;
using Azulano.repository;
using Microsoft.AspNetCore.Mvc;

namespace Azulano.Controllers
{
    public class HabitatController : ControllerBase
    {
        private readonly HabitatRepository _habitatRepository;

        public HabitatController(HabitatRepository habitatRepository)
        {
            _habitatRepository = habitatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<HabitatModel>>> BuscarTodosHabitats() 
        {
            List<HabitatModel> habitats = await _habitatRepository.BuscarTodosHabitats();
            return Ok (habitats);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitatModel>> BuscarPorId(int id)
        {
            HabitatModel habitat = await _habitatRepository.BuscarPorId(id);
            return Ok(habitat);
        }

        [HttpPost]
        public async Task<ActionResult<HabitatModel>> Cadastrar([FromBody] HabitatModel habitatModelInserir)
        {
            var habitatModel = new HabitatModel();
            habitatModel.NameHabitat = habitatModelInserir.NameHabitat;
            habitatModel.DescricaoHabitat = habitatModelInserir.DescricaoHabitat;
            habitatModel.Localizacao = habitatModelInserir.Localizacao;

            HabitatModel habitat = await _habitatRepository.Adicionar(habitatModel);
            return Ok(habitat);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}