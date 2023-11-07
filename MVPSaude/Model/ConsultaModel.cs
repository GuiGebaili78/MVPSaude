using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.MVPSaude.Models
{

    [Table("CONSULTA")]
    public class ConsultaModel
    {
        [HiddenInput]
        [Key]
        [Column("CONSULTAID")]
        public int ConsultaId { get; set; }

        [Display(Name = "Paciente")]
        [Column("PACIENTEID")]
        public int PacienteId { get; set; }
        public PacienteModel? Paciente { get; set; }

        [Display(Name = "Médico")]
        [Column("MEDICOID")]
        public int MedicoId { get; set; }
        public MedicoModel? Medico { get; set; }

        [Display(Name = "Data da Consulta")]
        [Required(ErrorMessage = "Data da consulta é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data da consulta inválida")]
        [Column("DATACONSULTA")]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Hora da Consulta")]
        [Required(ErrorMessage = "Hora da consulta é obrigatória")]
        [DataType(DataType.Time, ErrorMessage = "Hora da consulta inválida")]
        [Column("HORACONSULTA")]
        public DateTime HoraConsulta { get; set; }

        [Column("LOCAL")]
        [StringLength(255,
          MinimumLength = 1,
          ErrorMessage = "O endereço deve ter, no mínimo, 1 e, no máximo, 255 caracteres")]
        [Display(Name = "Local")]
        public string? Local { get; set; }

        [Column("MENSAGEM")]
        [StringLength(4000,
          MinimumLength = 1,
          ErrorMessage = "A mensagem deve ter, no mínimo, 1 e, no máximo, 4000 caracteres")]
        [Display(Name = "Mensagem")]
        public string? Mensagem { get; set; }
        public int Id { get; }
        public string V { get; }

        public ConsultaModel()
        {
        }

        public ConsultaModel(int consultaId, PacienteModel? paciente)
        {
            ConsultaId = consultaId;
            Paciente = paciente;
        }

        public ConsultaModel(int id, string v)
        {
            Id = id;
            V = v;
        }
    }
}