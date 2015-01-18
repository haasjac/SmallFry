using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace SpaceJam{
public class EndGameController : MonoBehaviour {
		public string lvl_name = "";
		public string lvl_name_fail = "";
		private static Text scoreText;
		private bool wincon;
		private bool gamend;

		void Start()
		{
			scoreText = GameObject.Find("/Canvas/ENDText").GetComponent<Text>();
			scoreText.text = "";
			scoreText.color = Color.black;
				}



		void Update ()
		{
			if (gamend) 
			{
				if (wincon){
				if (Input.GetButtonDown("X_button"))
				{
					Application.LoadLevel(lvl_name);
				}}
				else{
					if (Input.GetButtonDown("X_button"))
					{
						Time.timeScale = 1;
						Application.LoadLevel(lvl_name_fail);
					}
					if (Input.GetButtonDown("X_button"))
					{
						Time.timeScale = 1;
						Application.LoadLevel(lvl_name);
					}

				}
				
			}
				

		}
		
		void OnTriggerEnter2D(Collider2D coll) {
			if (coll.gameObject.tag == "Player") 
			{
				print("PLAYER");
				scoreText.text = "Congratulations! Press X to continue";
				Time.timeScale = 0;
				wincon = true;	
				gamend = true;
			}
			else 
			{
				print ("OSTRICH");
				scoreText.text = "Try again? Press X to try again or B to go back";
				Time.timeScale = 0;
				wincon = false;
				gamend = true;
			}
		}

	}
}