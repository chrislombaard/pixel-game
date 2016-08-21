using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;

	private Rigidbody2D rbPlayer;
	private BoxCollider2D boxCollider;
	private float inverseSpeed;
	private Animator animator;
	private bool candle = true;
	private bool idle = true;


	void Start(){
		animator = GetComponent<Animator> ();
		boxCollider = GetComponent<BoxCollider2D> ();
		rbPlayer = GetComponent<Rigidbody2D> ();
		inverseSpeed = 1f / speed;
	}
			
	void Update () {

	
		//movex = Input.GetAxis ("Horizontal");
		//movey = Input.GetAxis ("Vertical");
		//rbPlayer.velocity = new Vector2 (movex * (speed / Time.deltaTime), movey * (speed / Time.deltaTime));
		if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d") || Input.GetKeyDown ("w") || Input.GetKeyDown ("s")) {
			idle = false;
			if (candle) {
				animator.SetTrigger ("1");
			}
			else {
				animator.SetTrigger ("3");
			}
		}else if (Input.GetKeyUp ("a") || Input.GetKeyUp ("d") || Input.GetKeyUp ("w") || Input.GetKeyUp ("s")){
			idle = true;
			if (candle) {
				animator.SetTrigger ("2");
			}
			else {
				animator.SetTrigger ("6");
			}
		}

		if (Input.GetKey ("a")) {
			transform.localScale = new Vector3 (-1, 1, 1);
			transform.Translate (Vector2.left * speed * Time.deltaTime);
		}
			
		if (Input.GetKey ("d")) {
			transform.localScale = new Vector3 (1, 1, 1);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}

		if (Input.GetKey ("w")) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
		}

		if (Input.GetKey ("s")) {
			transform.Translate (Vector2.down * speed * Time.deltaTime);
		}

		if (Input.GetKey ("c")) {
			if (candle) {
				if (idle) {
					animator.SetTrigger ("3");
				} else {
					animator.SetTrigger ("7");
				}

				candle = false;
			} else {
				if (idle) {
					animator.SetTrigger ("4");
				} else {
					animator.SetTrigger ("8");
				}
				candle = true;
			}

		}

	}
}
