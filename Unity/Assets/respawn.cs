using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {
	private float x;
	private float y;
	private bool pole = false;
	// Use this for initialization
	void Start () {
		x = transform.position.x;
		y = transform.position.y;
	}
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Respawn") {
			Vector3 pos = new Vector3(x,y,0f);
			transform.position = pos;
			pole = false;
		}
		if (coll.gameObject.tag == "Pole") {
			pole = true;
		}
	}
}
