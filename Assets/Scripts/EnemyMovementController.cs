using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {

    public float speed;
    
    //facing
    public GameObject enemyGraphic;
    Animator enemyAnimator;
    bool canFlip;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
    
    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;
    
	// Use this for initialization
	void Start () {
	  // enemyAnimator = GetComponent<Animator>(); // Add this when you have animations for the enemy
      enemyRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	   if(Time.time > nextFlipChance){
           if(Random.Range(0, 10) >= 5){
//               FlipFacing();
           }
           
           nextFlipChance = Time.time + flipTime;
       }
	}
}
