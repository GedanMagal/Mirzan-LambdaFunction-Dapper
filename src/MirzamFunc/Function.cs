using Amazon.Lambda.Core;
using Dapper;
using MirzamFunc.Models;
using RestSharp;
using System.Data.SqlClient;
using System.Globalization;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MirzamFunc;

public class Function
{
  private readonly RestClient _client;

  public Function()
  {
    _client = new RestClient($"https://viacep.com.br/ws/");
  }

  public void Handler(ILambdaContext context)
  {

    context.Logger.LogInformation($"{new { RequestId = context.AwsRequestId }}");

    const string DATABASE_NAME = "[teste].[dbo].[TesteFunction]";
    const string CONNECTION_STRING = "SQL Server connection";

    var input = "08111430";

    var request = new RestRequest($"{input}/json/", Method.Get);

    var response = _client.GetAsync<Address>(request).Result;

    if (response == null)
      context.Logger.LogWarning($"Cannot complete the transaction, the object response is null");

    context.Logger.LogInformation($"Body: {response.ToString()}");

    using (var connection = new SqlConnection(CONNECTION_STRING))

    {
      connection.Open();

      using (var transaction = connection.BeginTransaction())
      {

        try
        {
          var teste = new Address
          {
            Cep = response.Cep,
            Logradouro = response.Logradouro,
            Bairro = response.Bairro,
            Localidade = response.Localidade,
            CreatedAt = DateTime.UtcNow
          };

          var sqlInsert = $@"Insert into {DATABASE_NAME} VALUES(@Cep, @Logradouro, @Bairro,@Localidade, @CreatedAt)";
          var teste2 =  connection.Execute(sqlInsert, teste, transaction);

          transaction.Commit();

          context.Logger.LogInformation($"teste deploy {teste.ToString()}");


        }
        catch (Exception ex)
        {
          transaction.Rollback();
          context.Logger.LogError($"Cannot complete de transaction, ERROR: {ex}");

        }

        connection.Close();
      }
    }

  }
}


