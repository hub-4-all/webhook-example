const express = require('express');
const crypto = require('crypto');

const PUBLIC_KEY = `-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAn6MCMk6U4/CZGB5CQytk
QXpjeYHTuUYhRh8Ogaa5jg0fKdnCOepl7BzSd0yjJeZaCDOB8wZrAqbtiIMqFt6Z
zdJljBie97e3w8eoB/lxNCk5UzKzAkUwA0k5qP750Rr6aXub9hjiEdQtleRGbBRS
RroBnyn6orFEFzR6r7Ryravc2Aic/YMMFb1+MVLOo48HTXWz5cTWA4E0zc+25VBK
O/JDgPgH66EPV0KlOejAZBzcPSFt9IYaMCzTfoMzu+2nrlNxI3/7Laf90ftphV5P
Bf20mj/izoM0q4fXJ1K//9VPSfFYX33TVY0pYKyM7rnR312WHgbODVRfuP/qVf53
vwIDAQAB
-----END PUBLIC KEY-----
`;

const verifySignature = (signature, payload) => {
  const verifier = crypto.createVerify('RSA-SHA256');
  verifier.update(payload);
  return verifier.verify(PUBLIC_KEY, signature, 'base64');
};

const app = express();

app.use(express.json());

app.post('/', (req, res) => {
  const signature = req.get('X-Hub4all-Signature');

  if (!verifySignature(signature, JSON.stringify(req.body))) {
    console.log('Invalid signature');
    return res.status(400).send('Invalid signature');
  }

  console.log('Valid signature');
  res.status(200).send('Valid signature');
});

app.listen(3001, () => {
  console.log('Server is running on port 3001');
});
