using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class comic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("X_button")) {
			SceneManager.LoadScene("Beach_Penguin");
		}
	}
}
