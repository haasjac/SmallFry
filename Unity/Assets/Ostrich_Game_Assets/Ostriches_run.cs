using UnityEngine;
using System.Collections;
using System;

namespace SpaceJam{
public class Ostriches_run : MonoBehaviour {
	public float speed;
	public float wait_time;
	private float timer;
	private bool is_waiting;
	private Animator animator;
		private float rng = 0;
	// Use this for initialization
	void Start () {
		is_waiting = false;
		timer = wait_time;
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (OstrichMG_controller.start) {
			rng = UnityEngine.Random.Range (0f, .25f);
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
					animator.SetBool ("hide", true);
					is_waiting = true;
				} else {
					animator.SetBool ("hide", false);
					Vector3 pos = transform.position;
					pos.x += speed - rng;
					transform.position = pos;
				}
		
					/*if ( (transform.position.x - OstrichMG_player.playersPOS)  < 1) {
						Vector3 pos = transform.position;
						pos.x += UnityEngine.Random.Range (0,3) * speed;
						transform.position = pos;
				} 

					else if ( (transform.position.x - OstrichMG_player.playersPOS)  > 1) {
						Vector3 pos = transform.position;
						pos.x += UnityEngine.Random.Range (0,3) * speed;
						transform.position = pos;	
				}*/

			}
		}
	}
}
}
