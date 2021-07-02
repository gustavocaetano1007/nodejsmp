# nodejsmp
O crescente mercado de jogos para computador, consoles, smartphones, e o surgimento
de novas mecânicas de jogos (multijogadores) tem crescido e popularizado a utilização
de tecnologias que possibilitam a comunicação cliente-servidor de forma eficiente e com
menor custo. A disponibilidade de ambientes de desenvolvimento que possibilitam a
exportação do código fonte para várias plataformas têm facilitado o desenvolvimento de
jogos para uma ampla variedade de dispositivos. Com isso, se destaca o ambiente de
desenvolvido da Unity3D, pois além de prover uma licença pessoal gratuita para
usuários que não faturam mais que $100.000 dólares, dispõe de uma ampla variedade de
dispositivos compatíveis para exportação.
A quantidade de jogadores em um servidor varia de 2 a 100 jogadores
simultâneos como nos jogos “Ark Survival Evolved” e “Call of Duty”. Isso é um limite
imposto pela capacidade de tratar várias requisições simultâneas no mesmo servidor.
Além disso, engines limitam ou cobram uma taxa para a utilização do recurso
multijogador. A Unity3D, por exemplo, limita em 8 usuários simultâneos em um jogo
multijogador utilizando a licença gratuita. A utilização de tecnologias escaláveis que
utilizam “melhor” os recursos no servidor bem como disponibilizam um acesso fácil
para desenvolvedores com pouco recurso financeiro, abrem a possibilidade de aumentar
a quantidade de jogadores, diminuindo o custo de aquisições de vários servidores
juntamente com licenças e aumento da quantidade de interações em jogos multijogador
em tempo real.
As linguagens de programação como Java, PHP e C, trabalham com a criação de
um thread para cada requisição e consecutivamente aumenta a utilização de recursos da
memória física do servidor fazendo com que diminua a quantidade de conexões
simultâneas suportadas. A maioria das linguagens tem comportamento bloqueante no 
thread em que estão, ou seja, se um cliente faz uma consulta pesada no banco de dados,
a thread utilizada fica travada até essa consulta terminar.
Com a necessidade de criar uma solução que gerencia melhor múltiplas
conexões com o servidor, foi desenvolvido o interpretador em JavaScript NodeJS que
funciona no lado do servidor. O NodeJS é fundamentado no interpretador de código
aberto criado pela Google V8 JavaScript Engine e baseado em C++ que funciona no
navegador Chrome; foi criado por Ryan Dahl em 2009 e seu desenvolvimento é mantido
pela empresa Joyent. Por ter licença de código aberto, possibilita uma grande economia
no requisito licença.
NodeJS é um recurso excelente para interações ao vivo em um site ou programa
que possui muitas solicitações de entrada e retorno de dados, pois é orientado a eventos
não síncrono e não bloqueante ininterruptamente beneficiando as requisições de dados
de entrada e saída no servidor. Nisso, sua utilização em um servidor de jogos pode
aumentar o desempenho e um número maior de requisições em um único servidor.

Compilação do cliente na ferramenta Unity3D:

a) Para o reconhecimento do servidor pelo cliente instalado no celular, é necessário abrir o
código fonte pelo Unity3D e informar o IP do servidor na opção Url, do grupo Socket IO
Component. Esse grupo é visualizado após selecionar a Network.cs, da pasta Assets.
b) Após alterar a URL acrescentando o IP correto do servidor, compile o projeto escolhendo
a opção File > Build & Run. Na lista à direita escolha a plataforma de destino e clique em
Build. Escolha uma pasta para salvar o arquivo com extensão .apk e clique em salvar.
2. Instalação do cliente no sistema operacional Android
Requisitos mínimos:
-Sistema operacional Android 4.4 ou superior.
-12 MB de memória ram.
-200MB memória interna.
a) Mova o arquivo Projeto_TCC2_nodejs.apk para a memória interna do celular.
b) Vá em configurações do celular, ache a opção “segurança”, e habilite fonte desconhecidas
conforme figura 01.
c) Abra o arquivo Projeto_TCC2_nodejs.apk salvo no dispositivo móvel.
d) Clique em próximo e aceite instalar.
e) Imprima numa folha de tamanho A4 a imagem 02.
f) Execute o aplicativo pressionando sobre o ícone criado em aplicativos e aponte a câmera
do dispositivo para a folha impressa.
3. Instalação do servidor NodeJS
a) Baixe a última versão do instalador NodeJS conforme seu sistema operacional no link
https://nodejs.org/en/download/.
b) Abra a pasta server localizada na raiz da pasta do trabalho pelo Terminal de Comandos do
sistema operacional.
c) Execute o comando node server.js
