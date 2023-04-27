using GisaDominio.Entidades;
using GisaDominio.Enum;
using System.Text.Json.Serialization;

namespace Infra.DTO
{
    public class AssociadoDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
        [JsonPropertyName("sobrenome")]
        public string? Sobrenome { get; set; }
        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; }
        [JsonPropertyName("estadoCivil")]
        public EstadoCivilEnum EstadoCivil { get; set; }
        [JsonPropertyName("sexo")]
        public SexoEnum Sexo { get; set; }
        [JsonPropertyName("naturalidade")]
        public UfEnum Naturalidade { get; set; }
        [JsonPropertyName("naturalidadeCidade")]
        public string? NaturalidadeCidade { get; set; }
        [JsonPropertyName("numeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [JsonPropertyName("ufDocumento")]
        public UfEnum UfDocumento { get; set; }
        [JsonPropertyName("orgaoDocumento")]
        public string? OrgaoDocumento { get; set; }
        [JsonPropertyName("dataEmissaoDocumento")]
        public DateTime DataEmissaoDocumento { get; set; }
        [JsonPropertyName("nomeMae")]
        public string? NomeMae { get; set; }
        [JsonPropertyName("nomePai")]
        public string? NomePai { get; set; }
        //[JsonPropertyName("endero")]
        //public virtual Endereco? Endereco { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }
        [JsonPropertyName("situacao")]
        public SituacaoAssociadoEnum Situacao { get; set; }
        //[JsonPropertyName("plano")]
        //public virtual Plano? Plano { get; set; }
        [JsonPropertyName("enderecoId")]

        public long EnderecoId { get; set; }
        [JsonPropertyName("planoId")]
        public long? PlanoId { get; set; }
    }
}
