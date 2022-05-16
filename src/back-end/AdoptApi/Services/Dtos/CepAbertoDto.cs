using Newtonsoft.Json;

namespace AdoptApi.Services.Dtos;

public class CepAbertoDto
{
    public class Cidade
    {
        public string ibge { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string nome { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public int? ddd { get; set; }
    }

    public class Estado
    {
        public string sigla { get; set; }
    }

    public Cidade cidade { get; set; }
    public Estado estado { get; set; }
    public double altitude { get; set; }
    [JsonProperty(Required = Required.Always)]
    public string longitude { get; set; }
    public string bairro { get; set; }
    public string complemento { get; set; }
    public string cep { get; set; }
    public string logradouro { get; set; }
    [JsonProperty(Required = Required.Always)]
    public string latitude { get; set; }
}