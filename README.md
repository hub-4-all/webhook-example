# Webhooks Hub4All

Os Webhooks da Hub4All são uma forma eficaz de receber notificações sobre eventos específicos da sua conta. Para sua maior segurança, assinamos todas as requsições HTTP com uma chave privada, enquanto disponibilizamos uma chave pública para que você possa validar a autenticidade de cada chamada. A chave pública pode ser encontrada na seção de configurações do webhook no portal do parceiro.

## Validação da assinatura

A validação da assinatura funciona em três passos:

1. Transformar o payload (corpo da requisição) em Buffer.
2. Utilizar uma biblioteca criptográfica para criar um verificador do tipo RSA-SHA256 (a maioria das stacks possuem uma nativa).
3. Utilizar a chave pública fornecida pela Hub4All para validar se o payload e a assinatura são válidos.

Para facilitar a integração, disponibilizamos um exemplo em Node.js e outro em .NET/C# para que você possa basear sua implementação.
