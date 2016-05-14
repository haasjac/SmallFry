using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SpaceJam {
public class Peacock_Game : MonoBehaviour {

	public float decrease_time = 0.25f;
	public float Time_of_Game = 15f;
	Text buttonText;
	Text scoreText;
	private float game_time = 0;
	private float switch_time = 0;
	private float cooldown = 0;
	private float d_time = 0;
	private int mash = 0;
	private int button = 0;
	private bool start = false;
	private bool go = false;
	private float go_time = 4f;
	Image bar;
	Image smashButton;
	CanvasGroup smashPanel;
	private Animator peacock;
	private Animator fish;

	// Use this for initialization
	void Start () {
		buttonText = GameObject.Find ("/Canvas/ButtonText").GetComponent<Text>();
		scoreText = GameObject.Find("/Canvas/ScoreText").GetComponent<Text>();
		scoreText.text = "";
		scoreText.color = Color.black;
		bar = GameObject.Find("ProgBar/Fill").GetComponent<Image>();
		smashButton = GameObject.Find("Mash/Button").GetComponent<Image>();
		smashPanel = GameObject.Find ("Mash").GetComponent<RectTransform>().GetComponent<CanvasGroup>();
		smashPanel.alpha = 0.0f;
		peacock = GameObject.Find ("Peacock_peacock").GetComponent<Animator>();
		fish = GameObject.Find ("Fish_peacock").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		// TODO: Change from Interact to X_button
		fish.SetInteger ("pose", button);
		peacock.SetInteger ("pose", button);
		if (Input.GetButtonDown ("X_button") && start == false) {
			GameObject.Find("Explanation Panel").GetComponent<CanvasGroup>().alpha = 0.0f;
			start = true;
		}

		if (start) {
			scoreText.text = Mathf.FloorToInt(go_time).ToString();
			go_time -= Time.deltaTime;
			if (go_time <= 1) {
				start = false;
				go = true;
				smashPanel.alpha = 1.0f;
			}
		}

		if (game_time < Time_of_Game && go) {
			if (game_time < switch_time) {
			} else {
				switch_time += Random.Range(2, 4);
				button = Mathf.FloorToInt(Random.Range (1, 4.99F));
			}
			//print (button);
			if (Input.GetButtonDown ("A_button") && button == 1) {
				mash ++;
			} else if (Input.GetButtonDown ("A_button")) {
				mash --;
			}
			if (Input.GetButtonDown ("B_button") && button == 2) {
				mash ++;
			} else if (Input.GetButtonDown ("B_button")) {
				mash --;
			}
			if (Input.GetButtonDown ("X_button") && button == 3) {
				mash ++;
			} else if (Input.GetButtonDown ("X_button")) {
				mash --;
			}
			if (Input.GetButtonDown ("Y_button") && button == 4) {
				mash ++;
			} else if (Input.GetButtonDown ("Y_button")) {
				mash --;
			}
			game_time += Time.deltaTime;

			if (d_time > decrease_time) {
				d_time = 0;
				if (mash > 0)
					mash -= 1;
				else 
					mash = 0;
			}
			d_time += Time.deltaTime;
			if (button == 1) {
				smashButton.sprite = Resources.Load<Sprite>("Sprites/A Button");
			} else if (button == 2) {
				smashButton.sprite = Resources.Load<Sprite>("Sprites/B Button");
			} else if (button == 3) {
				smashButton.sprite = Resources.Load<Sprite>("Sprites/X Button");
			} else if (button == 4) {
				smashButton.sprite = Resources.Load<Sprite>("Sprites/Y Button");
			}

			if (mash < 100) {
				bar.fillAmount = mash / 100f;
				if (mash < 25)
					bar.color = Color.magenta;
				else if (mash < 50)
					bar.color = Color.red;
				else if (mash < 75)
					bar.color = Color.yellow;
				else
					bar.color = Color.green;
			} else {
				bar.fillAmount = 1f;
				bar.color = Color.green;
			}
			scoreText.text = "Time: " + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n Score: " + mash;
		} else if (go) {
			smashPanel.alpha = 0.0f;
			buttonText.color = Color.black;
			if (mash > 100)
				buttonText.text = "You are amazing, darling!";
			else if (mash > 75)
				buttonText.text = "You're a natural!";
			else if (mash > 50)
				buttonText.text = "You're almost there, try again!";
			else if (mash > 25)
				buttonText.text = "At least you've got a great personality!";
			else 
				buttonText.text = "Umm...";

			if (mash > 75)
					GlobalState.instance.peacockGameComplete = true;

			buttonText.text += "\r\nPress X to try again\r\nPress B to leave";
			cooldown += Time.deltaTime;
			if (cooldown > 1f) {
				if (Input.GetButtonDown ("X_button")) {
					buttonText.text = "";
					start = true;
					go = false;
					go_time = 4f;
					game_time = 0;
					switch_time = 0;
					mash = 0;
					button = 0;
				}
				if (Input.GetButtonDown ("B_button")) {
					SceneManager.LoadScene("Garden");
				}
			}
		}
	}
}
}
