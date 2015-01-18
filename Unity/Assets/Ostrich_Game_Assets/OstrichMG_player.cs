using UnityEngine;
using UnityEngine.UI;
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
		public  float Wait_time;
		private float wait_time;
		public static bool move_enable;
		public int hp;
		private static Text scoreText;
		//private Transform groundCheck;
			
		// Use this for initialization
		void Start () {
			wait_time = 0;
			scoreText = GameObject.Find("/Canvas/HPText").GetComponent<Text>();
			scoreText.text = "";
			scoreText.color = Color.black;
			//groundCheck = transform.Find ("groundCheck");
		}
		
		// Update is called once per frame 
		void Update () {
			scoreText.text = "Lives left:" + hp;
			playersPOS = transform.position.x;

		if (hp < 1) {
				OstrichMG_controller.start = false;
				scoreText.text = "Try again? Press X to try again or B to go back";
				if (Input.GetButtonDown("X_button"))
				    {
					Application.LoadLevel("Ostrich_Game");
					}	
				if (Input.GetButtonDown("B_button"))
				{
					Application.LoadLevel("Desert");
				}
						}
		player_is_safe = false;
		if (Input.GetButton("Hide")) {	
						player_is_safe = true;
						Accelerate = 0;
						//ANIMATION running -> Hiding
				} 
		else player_is_safe = false;
	
		if (OstrichMG_controller.crouch_time && !player_is_safe ) {
								// GET REKT!!
				hp--;
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
