using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
						//Time.timeScale = 1;
						SceneManager.LoadScene(lvl_name);
				}}
				else{
					if (Input.GetButtonDown("X_button"))
					{
						//Time.timeScale = 1;
						SceneManager.LoadScene(lvl_name_fail);
					}

				}
				
			}
				

		}
		
		void OnTriggerExit2D(Collider2D coll) {
			if (coll.gameObject.tag == "Player") 
			{
				OstrichMG_controller.start = false;
				OstrichMG_controller.lose = true;
				print("PLAYER");
				GlobalState.instance.ostrichGameComplete = true;
				scoreText.text = "Congratulations! Press X to continue";
				//Time.timeScale = 0;
				wincon = true;	
				gamend = true;
			} else 
			{
				OstrichMG_controller.start = false;
				OstrichMG_controller.lose = true;
				print ("OSTRICH");
				scoreText.text = "Try again? Press X";
				//Time.timeScale = 0;
				wincon = false;
				gamend = true;
			}
		}

	}
}