using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset theText;
    public int startLine;
    public int endLine;
    public bool collided;
    public Text speak;
    public  bool isSpeak;
    string playerName;
    int numSpeaks = 0;
    
    public TextBoxManager textManager;
    
    public bool destroyWhenActivated;
	// Use this for initialization
	void Start () {
	   textManager = FindObjectOfType<TextBoxManager>();
       isSpeak = false;
	}
	
	// Update is called once per frame
	void Update () {
	   if(collided){
			if(Input.GetButtonUp ("Select")){
                if(isSpeak){
                    Debug.Log("I'm here");
                    LoadDialogueBox();	
                    isSpeak = false;	    
                }
                
			}            
		}
	}
    
    void OnCollisionEnter2D(Collision2D other){
        collided = true;
        speak.enabled = true;
        Debug.Log("Just Entered!");
        isSpeak = true;
        if(other.gameObject.GetComponent<PlayerMovement>().facing == 1)
                speak.rectTransform.position = new Vector2(other.transform.position.x + 17, other.transform.position.y + 15);       
            else if(other.gameObject.GetComponent<PlayerMovement>().facing == -1)
                speak.rectTransform.position = new Vector2(other.transform.position.x - 17, other.transform.position.y + 15); 
        playerName = other.gameObject.name;
    }
    
    void OnCollisionExit2D(Collision2D other) {
		//if (coll.gameObject.tag == "Enemy")
		//	coll.gameObject.SendMessage("ApplyDamage", 10);
        Debug.Log("Just Exited!");
		collided = false;
        speak.enabled = false;
        isSpeak = false;

	}
    
    void LoadDialogueBox(){
        if((playerName == "Player") && isSpeak){      
            Debug.Log("Load Dialogue Box");      
            textManager.ReloadScript(theText);
            textManager.currentLine = startLine;
            textManager.endAtLine = endLine;
            textManager.EnableTextBox();
            //if(destroyWhenActivated){
              //  Destroy(gameObject);
            //}
        }
    }
}
