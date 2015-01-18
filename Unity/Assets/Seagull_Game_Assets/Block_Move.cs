using UnityEngine;
using System.Collections;

public class Block_Move : MonoBehaviour {
	public bool direction = false;
	public int distance = 0;
	private int i;
	public float bump = 1;
	private GameObject fish;
	// Use this for initialization
	void Start () {
		i = 0;
		fish = GameObject.Find("Fish");
	}
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (direction)
			pos.y -= bump;
		else
			pos.x += bump;
		transform.position = pos;
		i++;
		if (i > distance) {
			i=0;
			bump = -bump;
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && !direction) {
			Vector3 posf = fish.transform.position;
			posf.x += 1.2f*bump;
			fish.transform.position = posf;
		}
	}

}
