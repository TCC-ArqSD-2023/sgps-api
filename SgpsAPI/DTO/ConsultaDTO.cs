using GisaDominio.Entidades;
using GisaDominio.Enum;

namespace SgpsAPI.DTO
{
    public class ConsultaDTO
    {
        public long? Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public long PrestadorId { get; set; }
        public string? PrestadorNome { get; set; }
        public long? PacienteId { get; set; }
        public string? PacienteNome { get; set; }
        public SituacaoAtendimentoEnum? Situacao { get; set; }
    }
}
