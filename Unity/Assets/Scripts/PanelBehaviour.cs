using UnityEngine;
using System.Collections;

public class PanelBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("X_button")) {
			GameObject.Find ("Explanation Panel").GetComponent<CanvasGroup>().alpha = 0.0f;
		}
	}
}
