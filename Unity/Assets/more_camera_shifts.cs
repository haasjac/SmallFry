using UnityEngine;
using System.Collections;

public class more_camera_shifts : MonoBehaviour {
	public float speed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed * -Input.GetAxis ("Horizontal");
		transform.position = pos;
	}
}
