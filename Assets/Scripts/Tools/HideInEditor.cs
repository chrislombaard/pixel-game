 using UnityEngine;
 using System.Collections;
 
 [ExecuteInEditMode]
 public class HideInEditor : MonoBehaviour {
     void OnEnable () {
         gameObject.SetActive(!Application.isEditor || Application.isPlaying);
     }
     
     void OnDisable () {
         gameObject.SetActive(true);
     }
 }