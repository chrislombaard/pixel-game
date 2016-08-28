// using UnityEngine;
// using System.Collections;
// using System.IO;
// using UnityEngine.UI;

// public class ItemData : MonoBehaviour {

// 	BoxCollider2D bcMatches;
// 	Inventory inventory;
// 	bool collided;
// 	public Item item;
// 	public int amount;
// 	public int itemUsed;
//     public int index;
//     public Text pickup;

// 	// Use this for initialization
// 	void Start () {
// 		collided = false;
// 		bcMatches = GetComponent<BoxCollider2D> ();
// 		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
// 	}

// 	// Update is called once per frame
// 	void Update () {
// 		if(collided){
// 			if(Input.GetButtonUp ("Select")){
// 				Debug.Log ("Picked up: " + item.Title);
// 				inventory.AddItemNew (item.ID);
// 				Destroy (gameObject);
// 			}            
// 		}
// 	}

// 	void OnCollisionEnter2D(Collision2D other) {
// 		//if (coll.gameObject.tag == "Enemy")
// 		//	coll.gameObject.SendMessage("ApplyDamage", 10);
// 		Debug.Log("We just collided with something!");
// 		collided = true;
//         pickup.enabled = true;
//         if(other.gameObject.GetComponent<PlayerMovement>().facing == 1)
//             pickup.rectTransform.position = new Vector2(other.transform.position.x + 17, other.transform.position.y + 15);       
//         else if(other.gameObject.GetComponent<PlayerMovement>().facing == -1)
//             pickup.rectTransform.position = new Vector2(other.transform.position.x - 17, other.transform.position.y + 15); 
        

// 	}

// 	void OnCollisionExit2D(Collision2D other) {
// 		//if (coll.gameObject.tag == "Enemy")
// 		//	coll.gameObject.SendMessage("ApplyDamage", 10);
// 		Debug.Log("We just exited!");
// 		collided = false;
//         pickup.enabled = false;

// 	}



// }
