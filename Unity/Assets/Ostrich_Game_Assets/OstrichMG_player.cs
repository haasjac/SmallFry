﻿using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class OstrichMG_player : MonoBehaviour
	{
		public float speed;
		public float jumpForce;
		private bool grounded;
		private bool jump;
		public float Accelerate;
		public static float playersPOS;
		public static bool player_is_safe;
		//private Transform groundCheck;
			
		// Use this for initialization
		void Start () {
			//groundCheck = transform.Find ("groundCheck");
		}
		
		// Update is called once per frame 
		void Update () {
		player_is_safe = false;
		if (Input.GetAxis ("Vertical") < 0) {	
						player_is_safe = true;
						Accelerate = 0;
						print ("CROUCHING");
						//ANIMATION running -> Hiding
				} 
		else player_is_safe = false;
	
		if (OstrichMG_controller.crouch_time && !player_is_safe) {
			// GET REKT!!
			Vector3 pos = transform.position;
			pos.x = -300.0f ;
			playersPOS = pos.x;
			transform.position = pos;
		}
		player_is_safe = false;
	
	
		/*if (Input.GetAxis ("Horizontal") != 0) {
			if (Input.GetAxis ("Horizontal") > 0)
			{
				Accelerate+= 0.01f;
				Vector3 pos = transform.position;
				pos.x += Accelerate + speed ;
				playersPOS = pos.x;
				transform.position = pos;
			}
		else Accelerate = 0;
		*/
	
				
				
			//}
		}
	}
}
