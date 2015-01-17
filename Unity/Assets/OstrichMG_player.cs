using UnityEngine;
using System.Collections;
//using spaceJam{
	public class OstrichMG_player : MonoBehaviour {
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
		bool crouch_time = false;
		if (Mathf.CeilToInt (UnityEngine.Random.Range (1, 3)) % 3 == 0)
			crouch_time = true;


			if (Input.GetAxis ("Horizontal") != 0) {
				if (Input.GetAxis ("Horizontal") > 0)
				{
					Accelerate+= 0.01f;
					Vector3 pos = transform.position;
					pos.x += Accelerate + speed ;
					playersPOS = pos.x;
					transform.position = pos;
				}
			else Accelerate = 0;
			if (Input.GetAxis ("Vertical")< 0 )
			{	
				player_is_safe = true;
				print("CROUCHING");
				//ANIMATION running -> Hiding
			}

				
				
			}
		}
	}
//}