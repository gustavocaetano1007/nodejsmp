using UnityEngine;
using System.Collections;
using Vuforia;
 
public class ScreenClicker : MonoBehaviour {

	//Classe responsável pela detecção da posição do aperta tecla

	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;
	  
	    void Start () {
			
		       
		    }
	     
	    
	    void Update () {

		Touch touch = Input.GetTouch(0);

		switch (touch.phase)
		{
		// Gravar posicao inicial do touch
		case TouchPhase.Began:
			startPos = touch.position;
			directionChosen = false;

			break;

			// Determine a direção comparando a posição de toque atual com a inicial.
		case TouchPhase.Moved:
			direction = touch.position - startPos;

			break;

			// Informe que uma direção foi escolhida quando o dedo é levantado.
		case TouchPhase.Ended:
			directionChosen = true;
			Clicked (touch.position);
			break;
		}


	}

	//Função captura colisor.

	void Clicked (Vector2 position) {
		

		var ray = Camera.main.ScreenPointToRay (position);
		RaycastHit rhit = new RaycastHit();
	
		if (Physics.Raycast (ray, out rhit)) {

			var clickMove = rhit.collider.gameObject.GetComponent<ClickMove> ();
			clickMove.OnClick (rhit.point);


		}

	}
}
