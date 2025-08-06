using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ProducaoTematicaAPI.Models
{
    [Table("SITECTB104_SISTEMA")]
    public class Sistema
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        public int CO_SISTEMA {  get; set; }

        [Required]
        [StringLength(255)]
        public string SISTEMA {  get; set; }

        [StringLength(50)]
        public string SIGLA {  get; set; }

        [Required]
        public string LINK {  set; get; }

        [Required]
        public int CORPORATIVO {  get; set; }
        
        [Required]
        public int MACROPROCESSO {  get; set; }
    }
}