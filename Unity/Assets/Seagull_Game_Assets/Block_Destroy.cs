using UnityEngine;
using System.Collections;

public class Block_Destroy : MonoBehaviour {
	public float timer;
	public float speed;
	private float timerhalf;
	private bool timer_flag = false;
	// Use this for initialization
	void Start () {
		timerhalf = timer / 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer_flag) {
			timer -= Time.deltaTime;
		}
		if (timer < timerhalf) {
			Vector3 pos = transform.position;
			pos.y -= speed;
			transform.position = pos;		
		}
		if (timer < 0) {
			Destroy(this.gameObject);		
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
						//print ("WatchOUT!");
						timer_flag = true;
				}
	}
}
