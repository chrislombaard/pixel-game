using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator anim;
	private bool isCandle = true;
	private Rigidbody2D rbPlayer;
	private Light light;
	public float speed = 300f;
    public bool canMove;
    public int facing;

	// Use this for initialization
	void Start () {
        canMove = true;
		anim = GetComponent<Animator> ();
		rbPlayer = GetComponent<Rigidbody2D> ();
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int inputX = (int)Input.GetAxisRaw ("Horizontal");
		int inputY = (int)Input.GetAxisRaw ("Vertical");

		bool isWalking = Mathf.Abs (inputX) + Mathf.Abs (inputY) > 0;

		anim.SetBool ("isWalking", isWalking);
        int currX = (int)this.transform.position.x;
        int diff = (int)currX + inputX;
        
        if(diff < currX){
            facing = -1;
        }else if (diff > currX){
            facing = 1;
        }
        if(!canMove){
            anim.SetBool("isWalking", false);    
        }
        
		if (isWalking && canMove) {
			anim.SetFloat ("x", inputX);
			anim.SetFloat ("y", inputY);
            Debug.Log((int)(inputX * speed * Time.deltaTime));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 ((int)(inputX * speed * Time.deltaTime), (int)(inputY * speed * Time.deltaTime));
			//transform.position += new Vector3 (inputX * Time.deltaTime, inputY * Time.deltaTime, 0).normalized;
		}

		if (Input.GetKeyDown ("c")) {
			if (isCandle) {
				anim.SetBool ("isCandle", false);
				isCandle = false;
			} else {
				anim.SetBool ("isCandle", true);
				isCandle = true;
			}
		}

	}
}
