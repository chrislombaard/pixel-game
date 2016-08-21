using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private bool showInventory;
	private GameObject inventoryUI;
    public GameObject pauseMenu;
    private bool paused = false;
    public GameObject[] theObjects;
    List<GameObject> objectsToDisable; 
	// Use this for initialization
	void Start () {
		//ShowInventory(false);
		
	}

	void Awake(){
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Paused")) {
			paused = !paused;
            Debug.Log("paused");
		}
			
        if(paused){ 
           pauseMenu.GetComponent<Canvas>().enabled = true;
           DisableAllObjects();
        }else{
            pauseMenu.GetComponent<Canvas>().enabled = false;
        }
	}
    
    void DisableAllObjects(){
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        objectsToDisable = new List<GameObject>(allObjects);
        foreach (GameObject a in allObjects) {
            foreach (GameObject b in theObjects) {
                if (a.name == b.name)
                    objectsToDisable.Remove(a);
            }
        }
        foreach (GameObject a in objectsToDisable)
            a.SetActive(false);
        
    }
}
