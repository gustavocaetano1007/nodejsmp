//Servidor em NodeJS para sincronização de dados em rede.
//Criação das variáveis.
var io = require('socket.io')(process.env.PORT || 3000);
var shortid = require('shortid');

console.log('servidor iniciado');

//Vetor de dados do jogador.
var players = [];

io.on('connection', function(socket){
    
    var thisPlayerId = shortid.generate();
    
    //para atualizar o movimento com novos clientes.
    var player = {
        
        id: thisPlayerId,
        x: 0, 
        y: 0
            
    };
    
    players[thisPlayerId] = player;
    
    console.log('cliente conectou, broadcast spawn, id:', thisPlayerId);
    //anexar ID do jogador
    socket.broadcast.emit('spawn', {id: thisPlayerId});
	
    //Atualizar posição de todos clientes
    socket.broadcast.emit('requestPosition');
    
    //para atualizar o movimento com novos clientes.
    for (var playerId in players) {
        
        if(playerId == thisPlayerId)
            continue;
        socket.emit('spawn', players[playerId]);
        console.log('Transmitindo um novo jogador para ID: ', playerId);
    };
    
      //Retransmitir posiçao do jogador
    socket.on('move', function(data) {
        data.id = thisPlayerId;
        console.log('cliente moveu', JSON.stringify(data));
        
        player.x = data.x;
        player.y = data.y;
        
        
        socket.broadcast.emit('move', data);
    });
    //atualizar posição do jogador
    socket.on('updatePosition', function(data) {
        console.log("Atualizando posição: ", data);
        data.id = thisPlayerId;
        socket.broadcast.emit('updatePosition', data);
    });
    
	//Função para fechar conexão do jogador.
    socket.on('disconnect', function () {
        console.log('Cliente desconectado.');
        
        delete players[thisPlayerId];
        
        socket.broadcast.emit('disconnected', {id: thisPlayerId});
    });   
    
   
})