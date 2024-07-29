# Projeto para Implementar uma Integração com o Gateway de Pagamento Asaas

Este projeto tem como objetivo implementar uma integração com o gateway de pagamento Asaas. Atualmente, o projeto está em desenvolvimento.

## Instalação

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/saulomlcosta/MudBlazorAppAsaasBilling.git

2. **Configuração**
- Ajuste a connection string:
Abra o arquivo de configuração appsettings.json, atualize a connection string para apontar para o seu banco de dados.
- Configure o accessToken relacionado ao Asaas:
No mesmo arquivo de configuração, adicione o seu accessToken fornecido pelo Asaas.
- Aplique as migrations.

2. **Uso**
- Se registre ou faça login na aplicação caso já tenha usuário.
- Na tela de Customers, crie/edite/delete seus consumidores.
- ![image](https://github.com/user-attachments/assets/d14494b6-90c0-45dc-9e4b-bc462979d63b)
- Após a criação cada um terá uma lista com cobranças crie/edite/delete.
- ![image](https://github.com/user-attachments/assets/dbdc26dc-c955-41a5-be31-2976c932809d)
- Foi implementado uma controller para simular o Webhook utilizado no Asaas.
- Com o payload, você consegue mandar para esse endpoint.
- ![image](https://github.com/user-attachments/assets/b9043735-be3c-4cf4-ac40-c76ba9bf0c62)
- Cobranças pagas, será atualizada na listagem de cobranças.

**EM DESENVOLVIMENTO...**







