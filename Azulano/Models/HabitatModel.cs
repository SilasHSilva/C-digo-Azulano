using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azulano.Models.Animals;
using Microsoft.AspNetCore.SignalR;

namespace Azulano.Models.Habitat
{
    [Table("T_AZL_HABITATS")]
    public class HabitatModel
    {
        [Key]
        [Column("ID")]
        public long Id {get; set; }

        [Key]
        [Column("NM_HABITAT")]
        public String NameHabitat {get; set; }

        [Key]
        [Column("DESCRICAO")]
        public String DescricaoHabitat {get; set; }

        [Key]
        [Column("LOCALIZACAO")]
        public String Localizacao {get; set;}

        [JsonIgnore]
        public ICollection<AnimalsModel> Animais { get; set; }
        
    }
}