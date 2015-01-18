using UnityEngine;
using System.Collections;

public class camera_seagull : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = GameObject.Find ("Fish").GetComponent<Transform> ().position.x;
		if (pos.x < 0)
			transform.position = new Vector3(0f, 0f, -10f);
				else if (pos.x < 26)
						transform.position = pos;
				else 
			transform.position = new Vector3(26f, 0f, -10f);
	}

}
