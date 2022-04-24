using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzamFunc.Models
{
  public class Address
  {
    public string Cep { get; set; }

    public string Logradouro { get; set; }

    public string Complemento { get; set; }

    public string Bairro { get; set; }

    public string Localidade { get; set; }

    public string UF { get; set; }

    public string Ibge { get; set; }

    public string Gia { get; set; }

    public string Ddd { get; set; }

    public string Siafia { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
