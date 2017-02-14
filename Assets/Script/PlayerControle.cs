using UnityEngine;
using System.Collections;

public class PlayerControle : MonoBehaviour {

	public Animator animacao;
	public Rigidbody2D playerRB;
	public int forceJump;

	bool slide;
	bool jump;


	// slide
	public float timeSlide;
	public float tempoTempo;


	// verifica chao
	public Transform groundCheck;
	public bool grounded;
	public LayerMask whatIsChao;

	public Transform colisor;

	// Use this for initialization
	void Start () {
		playerRB =  GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && grounded == true) {

			//Debug.Log ("Pulo");
			playerRB.AddForce(new Vector2(0, forceJump));
			if (slide == true) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
			}
			slide = false;
		}
		if (Input.GetButtonDown("Horizontal") && grounded == true) {
			Debug.Log ("Andando");
		}


		if(Input.GetButtonDown ("Slide") && grounded == true){
			//Debug.Log ("Slide");
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
			slide = true;
			tempoTempo = 0;
		}
		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsChao);

		if (slide == true) {
			tempoTempo += Time.deltaTime;
			if (tempoTempo >= timeSlide) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
		}

		animacao.SetBool ("jump", !grounded);
		animacao.SetBool ("slide", slide);


	}
}
