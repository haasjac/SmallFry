﻿using UnityEngine;
using System.Collections;
namespace SpaceJam{
public class Sgt_controller : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			if (OstrichMG_controller.crouch_time) {
			//Vector3 pos = 
				}

			if (OstrichMG_player.playersPOS - transform.position.x > 5) {
				Vector3 pos = transform.position;
				pos.x +=  speed;
				transform.position = pos;
			} 
			
			else if (OstrichMG_player.playersPOS - transform.position.x < 5) {
				Vector3 pos = transform.position;
				pos.x += 0.5f * speed;
				transform.position = pos;	
			}
			
		}
}
}
