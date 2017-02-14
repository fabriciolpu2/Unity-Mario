using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public float velocidadeX = 0.1f;
	public float movimentoX;
	public float inputX;
	public float forcaSalto = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float inputX = Input.GetAxis ("Horizontal");
		if (inputX > 0) {
			movimentoX = transform.position.x + (inputX * velocidadeX);
			transform.position = new Vector3 (movimentoX, transform.position.y);
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if(inputX < 0) {
			movimentoX = transform.position.x + (inputX * velocidadeX);
			transform.position = new Vector3 (movimentoX, transform.position.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			GetComponent <Rigidbody2D>().AddForce (new Vector2(0, forcaSalto));
		}

	}
}
