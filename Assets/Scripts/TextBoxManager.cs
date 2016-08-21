using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public TextAsset textFile;
    public string[] textLines;
    public GameObject textBox;
    public Text theText;
    public int currentLine;
    public int endAtLine;
    public PlayerMovement player;
    private GameObject inventory;
    public bool isActive;
    public bool stopPlayerMovement;
    private bool isTyping = false;
    private bool cancelTyping = false;
    
    public float typeSpeed;
    
	// Use this for initialization
	void Start () {
        
        player = FindObjectOfType<PlayerMovement>();
        inventory = GameObject.Find("Inventory UI");
        currentLine = 0;
        if(textFile != null){
            textLines = textFile.text.Split('\n');       
        }
        

        if (endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }
        
        if(isActive){
            EnableTextBox();
        }else{
            DisableTextBox();
        }
    
    }
    
    void Update(){
        
        if(!isActive){
            return;
        }
      //  Debug.Log("CurrentLine: " + currentLine + " endAtLine: " + endAtLine); 
        
        if(Input.GetButtonUp("Submit")){
            if(!isTyping){
                currentLine++;            
                if(currentLine > endAtLine){     
                    DisableTextBox();          
                }else{
                    StartCoroutine(TextScroll(textLines[currentLine]));
                } 
            }else if(isTyping && !cancelTyping){
                cancelTyping = true;
            }           
        }
    }
    //Coroutine parallel basically
    private IEnumerator TextScroll(string lineOfText){
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        
        while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1)){
            theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
            
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
        
    }
    
    public void EnableTextBox(){
        textBox.SetActive(true);  
        isActive = true;
        if(stopPlayerMovement){
            player.canMove = false;
        }
        inventory.SetActive(false);
        StartCoroutine(TextScroll(textLines[currentLine]));
    }
    
    public void DisableTextBox(){
        textBox.SetActive(false);  
        player.canMove = true;
        isActive = false;
        inventory.SetActive(true);
    }
    
    public void ReloadScript(TextAsset theText){
        if(theText != null){
            textLines = new string[1];
            textLines = theText.text.Split('\n');
        }
    }
}
