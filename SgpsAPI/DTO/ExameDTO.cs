using GisaDominio.Entidades;
using GisaDominio.Enum;

namespace SgpsAPI.DTO
{
    public class ExameDTO
    {
        public long? Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public long TipoExameId { get; set; }
        public string? TipoExameNome { get; set; }
        public long ConveniadoId { get; set; }
        public string? ConveniadoNome { get; set; }
        public long? PacienteId { get; set; }
        public string? PacienteNome { get; set; }
        public SituacaoAtendimentoEnum? Situacao { get; set; }
    }
}
