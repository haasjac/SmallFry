using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Peacock_Game : MonoBehaviour {

	public float decrease_time = 0.25f;
	public float Time_of_Game = 15f;
	Text buttonText;
	private float game_time = 0;
	private float switch_time = 0;
	private float d_time = 0;
	private int mash = 0;
	private int button = 1;
	private bool start = false;
	private bool go = false;
	private float go_time = 4f;

	// Use this for initialization
	void Start () {
		button = Mathf.FloorToInt(Random.Range (1, 4.99F));
		buttonText = GameObject.Find("/Canvas/ButtonText").GetComponent<Text>();
		buttonText.text = "Press Start";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit") && start == false) {
			buttonText.text = "Press Start";
			start = true;
		}

		if (start) {
			buttonText.text = Mathf.FloorToInt(go_time).ToString();
			go_time -= Time.deltaTime;
			if (go_time <= 1) {
				start = false;
				go = true;
			}
		}

		if (game_time < Time_of_Game && go) {
			if (game_time < switch_time) {
			} else {
				switch_time += Random.Range(2, 4);
				//print ("switch" + game_time);
				button = Mathf.FloorToInt(Random.Range (1, 4.99F));
				//print (button + " " + game_time);
			}
			//print (button);
			if (Input.GetButtonDown ("Fire" + button)) {
				if (mash < 23)
					mash += 3;
				else 
					mash = 25;
			}
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2") || 
			    Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire4")) {
				if (mash > 0)
					mash --;
				else 
					mash = 0;
			}
			game_time += Time.deltaTime;

			if (d_time > decrease_time) {
				d_time = 0;
				if (mash > 0)
					mash -= 2;
				else 
					mash = 0;
			}
			d_time += Time.deltaTime;
			if (button == 1) {
				buttonText.text = "Press A \r\n" + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n" + mash;
			} else if (button == 2) {
				buttonText.text = "Press B \r\n" + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n" + mash;
			} else if (button == 3) {
				buttonText.text = "Press X \r\n" + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n" + mash;
			} else if (button == 4) {
				buttonText.text = "Press Y \r\n" + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n" + mash;
			}
			if (mash > 20)
				buttonText.color = Color.green;
			else 
				buttonText.color = Color.red;
		} else if (go) {
			//go = false;
			//print ("done " + mash);
			if (mash > 12)
				buttonText.text = "Yippie kay ay motherfucker";
			else 
				buttonText.text = "You fucking suck";
		}

	}
}
