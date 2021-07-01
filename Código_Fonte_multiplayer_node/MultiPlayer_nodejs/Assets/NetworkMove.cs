using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkMove : MonoBehaviour {

	//Classe responsável por enviar posição para o servidor nodejs. 

	public SocketIOComponent socket;


	public void OnMove (Vector3 position)
	{
		// Enviar posição para o node
		Debug.Log ("Enviando posição para o node" + Network.VectorToJson(position));

		socket.Emit("move", new JSONObject (Network.VectorToJson(position)));
	}


}
