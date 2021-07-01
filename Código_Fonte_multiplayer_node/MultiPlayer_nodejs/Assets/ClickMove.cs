using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {
	
	//Classe responsável por emitir o comando de novo posicionamento à rede e ao jogador.

	public GameObject player;

	public void OnClick (Vector3 position) {
		var navPos = player.GetComponent<NavigatePosition> ();
		var netMove = player.GetComponent<NetworkMove> ();
		navPos.NavigateTo (position);
		netMove.OnMove (position);
	}
}
