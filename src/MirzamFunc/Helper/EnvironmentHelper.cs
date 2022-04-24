using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using System.Text;

namespace MirzamFunc.Helper
{
  public class EnvironmentHelper
  {

    //public static async Task<string> DecodeEnvironmentVariable(string variableName)
    //{
    //  // Retrieve env var text
    //  var encryptedBase64Text = Environment.GetEnvironmentVariable(variableName);
    //  // Convert base64-encoded text to bytes
    //  var encryptedBytes = Convert.FromBase64String(encryptedBase64Text);
    //  // Set up encryption context
    //  var encryptionContext = new Dictionary<string, string>();
    //  encryptionContext.Add("MirzanFunc", Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME"));
    //  // Construct client
    //  using (var client = new AmazonKeyManagementServiceClient())
    //  {
    //    // Construct request
    //    var decryptRequest = new DecryptRequest
    //    {
    //      CiphertextBlob = new MemoryStream(encryptedBytes),
    //      EncryptionContext = encryptionContext,
    //    };
    //    // Call KMS to decrypt data
    //    var response = await client.DecryptAsync(decryptRequest);
    //    using (var plaintextStream = response.Plaintext)
    //    {
    //      // Get decrypted bytes
    //      var plaintextBytes = plaintextStream.ToArray();
    //      // Convert decrypted bytes to ASCII text
    //      var plaintext = Encoding.UTF8.GetString(plaintextBytes);
    //      return plaintext;
    //    }
    //  }
    //}
  }
}
