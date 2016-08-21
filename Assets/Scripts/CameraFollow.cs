using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    Camera myCamera;
	// Use this for initialization
	void Start () {
	   myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	   myCamera.orthographicSize = (Screen.height / 100f) / 2f;
	}
}
