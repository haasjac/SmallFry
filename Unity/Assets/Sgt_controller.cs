﻿using UnityEngine;
using System.Collections;

public class Sgt_controller : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (OstrichMG_player.playersPOS - transform.position.x > 5) {
				Vector3 pos = transform.position;
				pos.x += UnityEngine.Random.Range (0, 6) * speed;
				transform.position = pos;
			} 
			
			else if (OstrichMG_player.playersPOS - transform.position.x < 5) {
				Vector3 pos = transform.position;
				pos.x += UnityEngine.Random.Range (0, 1) * speed;
				transform.position = pos;	
			}
			
		}
}
