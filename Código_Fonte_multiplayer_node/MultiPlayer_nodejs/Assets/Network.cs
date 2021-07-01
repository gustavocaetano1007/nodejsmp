using UnityEngine;
using System.Collections.Generic;
using SocketIO;

public class Network : MonoBehaviour {

	//Classe responsável por tratar as posições recebidas pelo nodejs e realizar um broadcast para todos os clientes.

	static SocketIOComponent socket;
	public GameObject playerPrefab;
	public GameObject myPlayer;
	Dictionary<string, GameObject> players;

	void Start()
	{
		//Portas de recebimento de informação do servidor nodejs
		
		socket = GetComponent<SocketIOComponent> ();
		socket.On ("open", OnConnected);
		//spawn: recebe dados dos outros jogadores
		socket.On ("spawn", OnSpawned);
		socket.On ("move", OnMove);
		socket.On ("registered", OnRegistered);
		socket.On ("disconnected", OnDisconnected);
		socket.On ("requestPosition", OnResquestPosition);
		socket.On ("updatePosition", OnUpdatePosition);

		players = new Dictionary<string, GameObject> ();

	}
	//Função conecte
	void OnConnected(SocketIOEvent e)
	{
		
		Debug.Log ("Conectado");
		//Dica: enviar informação para o servidor: socket.Emit ("teste");
	}
	//Função gerar jogador
	void OnSpawned(SocketIOEvent e)
	{
		Debug.Log ("Entrou" + e.data);
		var player = Instantiate (playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		if (e.data ["x"]) {
			var movePosition = new Vector3 (GetFloatFromJson (e.data, "x"), 0, GetFloatFromJson (e.data, "y"));

			var navigatePos = player.GetComponent<NavigatePosition> ();

			navigatePos.NavigateTo (movePosition);
		}

		players.Add (e.data ["id"].ToString (), player);
		Debug.Log ("count: " + players.Count);

	}
	//Função para mover jogador.

	void OnMove (SocketIOEvent e) 
	{
		Debug.Log ("Um jogador está movendo" + e.data);
	
		var position = new Vector3 (GetFloatFromJson (e.data, "x"), 0, GetFloatFromJson (e.data, "y"));

		var player = players [e.data ["id"].ToString ()];
			
		var navigatePos = player.GetComponent<NavigatePosition> ();

		//Envia posição do broadcast junto com ID do player.
		navigatePos.NavigateTo (position);

	}
	//Registrar identificação id do jogador.

	void OnRegistered (SocketIOEvent e)
	{
		Debug.Log ("Registrado id: " + e.data);
	}

	//Solicitar posição de outros jogadores

	void OnResquestPosition  (SocketIOEvent e)  
	{
		Debug.Log ("Requisitando posicao no mapa"); 
		socket.Emit("updatePosition", new JSONObject (Network.VectorToJson(myPlayer.transform.position)));

	}

	//Desconectar jogador

	void OnDisconnected (SocketIOEvent e) 
	{
		var id = e.data ["id"].ToString ();

		var player = players [id];
		Destroy (player);
		players.Remove (id);

		Debug.Log ("Cliente desconectado: " + e.data);
	}

	//atualizar posição do jogador

	void OnUpdatePosition (SocketIOEvent e) 
	{
		Debug.Log ("Atualizando posição: " + e.data);

		var position = new Vector3 (GetFloatFromJson (e.data, "x"), 0, GetFloatFromJson (e.data, "y"));

		var player = players [e.data ["id"].ToString ()];

		player.transform.position = position;
	}
	float GetFloatFromJson (JSONObject data, string key)
	{
		return float.Parse (data [key].ToString ().Replace ("\"", ""));
	}

	//Tratamento dos dados via JSON

	public static string VectorToJson (Vector3 vector)
	{
		return string.Format (@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);

	}

 }