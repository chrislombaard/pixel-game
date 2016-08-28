// using UnityEngine;
// using System.Collections;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class InventoryUI : MonoBehaviour {

// 	public Canvas menu; // Assign in inspector
// 	public bool isShowing;
// 	private Animator anim, animBlanket;
// 	private PlayerMovement playerMove;
// 	public Button[] buttons;
// 	public EventSystem eventSystem;
// 	public GameObject inventory;
//     public Transform target;

// 	void Start(){
// 		menu.enabled = false;
// 		isShowing = false;
// 		playerMove = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
// 		anim = GameObject.Find ("Player").GetComponent<Animator> ();
//         animBlanket = gameObject.transform.FindChild("Blanket").gameObject.GetComponent<Animator>();
// 	}

// 	void Update() {
// 		if (Input.GetButtonDown("Inventory")) {
// 			isShowing = !isShowing;
// 			menu.enabled = isShowing;

// 			playerMove.canMove = !isShowing;

// 		}	

// 		if(!isShowing){
// 			eventSystem.enabled = false;
// 		}

// 		if (isShowing) {
//             if(Input.GetButtonUp ("Delete")){           
// 			     inventory.GetComponent<Inventory>().DropItem (eventSystem.currentSelectedGameObject.GetComponent<ItemData> ().index);
// 		    }
//             //animBlanket.StartPlayback();
// 			eventSystem.enabled = true;
// 			anim.SetBool ("isWalking", false);
// 		}
//         if(target){
//             transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y - 30, target.position.z), 1f);
//         }
        
// 	}

// }