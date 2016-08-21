using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class IsometricSpriteRenderer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	   GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
	}
}
