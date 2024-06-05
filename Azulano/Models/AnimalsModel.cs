using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azulano.Models.Habitat;

namespace Azulano.Models.Animals
{
    [Table("T_AZL_SPECIES")]
    public class AnimalsModel
    {
        [Key]
        [Column("ID", TypeName = "NUMBER")]
        public long Id {get; set; }

        [Column("NM_CIENTIFICO")]
        [StringLength(100)]
        public required String NomeCientifico {get; set; }

        [Column("NM_COMUM")]
        [StringLength(100)]
        public required String NomeComum {get; set; }

        [Column("DESCRICAO")]
        [StringLength(100)]
        public required String Descricao {get; set; }

        [Column("ID_HABITAT")]
        public long HabitatId {get; set; }

        [ForeignKey("ID_HABITAT")]
        [JsonIgnore]
        public HabitatModel? Habitat{get; set; }

    }

}