using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraSetup : MonoBehaviour {

	public static float pixelsToUnits = 1f;
	public static float scale = 1f;
    public Transform target;
    public Transform dialogue;
    public Camera myCamera;
	public Vector2 nativeRes = new Vector2(192, 108);
    public float mSpeed = 1f;
    bool lightning = true;
    Color old;

	// Use this for initialization
	void Awake () {
		myCamera = GetComponent<Camera> ();

		if (myCamera.orthographic) {
			scale = Screen.height / nativeRes.y;
			pixelsToUnits *= scale;
			myCamera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
		}
        
        // StartCoroutine (Lightning ());
         
	}
    
    void Update(){
        if(target){
            transform.position = Vector3.Lerp(transform.position, target.position, mSpeed) + new Vector3(0, 0, -10);
        }
       
        if(dialogue){
            dialogue.position = Vector3.Lerp(target.position, new Vector3(target.position.x, target.position.y - 40, target.position.z), 1f) + new Vector3(8, 0, 0);
        }
        
    }
     
    IEnumerator Lightning()
    {   Color color = new Color();
        old = myCamera.backgroundColor;
        bool numFlash = false;
        float randomRange = Random.RandomRange(1, 5);
        color.a = 1;
        color.r = 240;
        color.g = 240;
        color.b = 255;
        while(lightning){   
            if(numFlash){         
                yield return new WaitForSeconds(5f + randomRange);
                myCamera.backgroundColor = color;
                yield return new WaitForSeconds(0.08f);
                myCamera.backgroundColor = old;
                yield return new WaitForSeconds(0.28f);
                myCamera.backgroundColor = color;
                yield return new WaitForSeconds(0.18f);
                myCamera.backgroundColor = old;
                numFlash = !numFlash;
            }else{
                yield return new WaitForSeconds(5f + randomRange);
                myCamera.backgroundColor = color;
                yield return new WaitForSeconds(0.08f);
                myCamera.backgroundColor = old;
                numFlash = !numFlash;
            }
        }
    }
    
}
