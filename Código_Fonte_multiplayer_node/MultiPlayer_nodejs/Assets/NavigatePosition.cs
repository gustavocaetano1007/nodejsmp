using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigatePosition : MonoBehaviour {
	NavMeshAgent agent;

	//Classe responsável por receber a posição do jogador e atualizar na tela.

	void Awake () {

		agent = GetComponent<NavMeshAgent> ();


	}


	public void NavigateTo (Vector3 position) {
		agent.SetDestination (position);

	}

	//Atualiza posição do jogador

	void Update() {
		GetComponent<Animator> ().SetFloat ("Distance", agent.remainingDistance);

	}

	}
