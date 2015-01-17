using UnityEngine;
using System.Collections;
using System;

namespace SpaceJam{
public class Ostriches_run : MonoBehaviour {
	public float speed;
	public float wait_time;
	private float timer;
	private bool is_waiting;
	// Use this for initialization
	void Start () {
		is_waiting = false;
		timer = wait_time;
	}
	
	// Update is called once per frame
	void Update () {

		if (is_waiting) {
			timer -= Time.deltaTime;			
		}
		if (timer < 1) {
			is_waiting = false;
			timer = wait_time;
		}
		if(!is_waiting) {
			if (OstrichMG_controller.crouch_time) {
					// GET REKT!!
					// ANIMATION: Running --> Hiding
					Vector3 pos = transform.position;
					//pos.x -= 20;
					transform.position = pos;
					is_waiting = true;
			}
	
			if (OstrichMG_player.playersPOS - transform.position.x > 5) {
					Vector3 pos = transform.position;
					pos.x += UnityEngine.Random.Range (3, 6) * speed;
					transform.position = pos;
			} 

			else if (OstrichMG_player.playersPOS - transform.position.x < 5 ) {
					Vector3 pos = transform.position;
					pos.x += UnityEngine.Random.Range (0, 3) * speed;
					transform.position = pos;	
			}

		}
	}
}
}
