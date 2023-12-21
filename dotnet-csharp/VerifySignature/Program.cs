using System.Security.Cryptography;
using System.Text;

class VerifySignatureExample
{
  static void Main()
  {
    string publicKey = @"
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAn6MCMk6U4/CZGB5CQytk
QXpjeYHTuUYhRh8Ogaa5jg0fKdnCOepl7BzSd0yjJeZaCDOB8wZrAqbtiIMqFt6Z
zdJljBie97e3w8eoB/lxNCk5UzKzAkUwA0k5qP750Rr6aXub9hjiEdQtleRGbBRS
RroBnyn6orFEFzR6r7Ryravc2Aic/YMMFb1+MVLOo48HTXWz5cTWA4E0zc+25VBK
O/JDgPgH66EPV0KlOejAZBzcPSFt9IYaMCzTfoMzu+2nrlNxI3/7Laf90ftphV5P
Bf20mj/izoM0q4fXJ1K//9VPSfFYX33TVY0pYKyM7rnR312WHgbODVRfuP/qVf53
vwIDAQAB
-----END PUBLIC KEY-----
";

    string signature = "<Assinatura_a_ser_verificada>";
    // Substitua <Assinatura_a_ser_verificada> pela assinatura que você quer verificar

    string payload = "{\"key\": \"value\"}"; // Substitua pelo payload que deseja verificar

    bool isVerified = VerifySignature(signature, payload, publicKey);

    if (isVerified)
    {
      Console.WriteLine("Assinatura verificada com sucesso!");
    }
    else
    {
      Console.WriteLine("Falha na verificação da assinatura.");
    }
  }

  static bool VerifySignature(string signature, string payload, string publicKey)
  {
    byte[] signatureBytes = Convert.FromBase64String(signature);
    byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

    using (RSA rsa = RSA.Create())
    {
      rsa.ImportFromPem(publicKey);

      bool verified = rsa.VerifyData(payloadBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

      return verified;
    }
  }
}
