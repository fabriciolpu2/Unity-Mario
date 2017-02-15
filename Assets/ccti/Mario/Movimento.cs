using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public float velocidadeX = 0.1f;
	public float movimentoX;
	public float posicaoAtual;
	public float inputX;


	// Salto
	public float forcaSalto = 100f;
	public Transform pe;
	public float tamanhoPe;
	public LayerMask soloMask;
	public bool noSolo;

	// Animacao
	Animator animator;

	void Awake() {
		animator = GetComponent<Animator> ();
	}

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
			movimentoX = posicaoAtual;
		}

		if(inputX < 0) {
			movimentoX = transform.position.x + (inputX * velocidadeX);
			transform.position = new Vector3 (movimentoX, transform.position.y);
			transform.localScale = new Vector3 (-1, 1, 1);
			movimentoX = posicaoAtual;
		}

		if (inputX != 0) {
			animator.SetFloat ("velocidadeX", 1);
		} else {
			animator.SetFloat ("velocidadeX", 0);
		}


		// Salto

		noSolo = Physics2D.OverlapCircle (pe.position, tamanhoPe,soloMask);
		if(noSolo) {
			animator.SetBool ("noSolo", true);
		} else {
			animator.SetBool ("noSolo", false);
		}
		//Debug.Log (noSolo);
		if(noSolo && Input.GetKeyDown(KeyCode.Space)) {
			GetComponent <Rigidbody2D>().AddForce (new Vector2(0, forcaSalto));
			animator.SetBool ("noSolo", false);
		}
	}
}
