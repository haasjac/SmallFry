﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
	Scrollbar bar;

	// Use this for initialization
	void Start () {
		button = Mathf.FloorToInt(Random.Range (1, 4.99F));
		buttonText = GameObject.Find("/Canvas/ButtonText").GetComponent<Text>();
		buttonText.text = "Press X";
		buttonText.color = Color.black;
		scoreText = GameObject.Find("/Canvas/ScoreText").GetComponent<Text>();
		scoreText.text = "";
		scoreText.color = Color.black;
		bar = GameObject.Find("/Canvas/BAR").GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mash < 100)
			bar.value = mash / 100f;
		else 
			bar.value = 1f;
		scoreText.text = "Time: " + Mathf.CeilToInt(Time_of_Game - game_time) + "\r\n Score: " + mash;
		if (Input.GetButtonDown ("Interact") && start == false) {
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
				buttonText.text = "Press A";
			} else if (button == 2) {
				buttonText.text = "Press B";
			} else if (button == 3) {
				buttonText.text = "Press X";
			} else if (button == 4) {
				buttonText.text = "Press Y";
			}
			if (button == 4)
				buttonText.color = Color.yellow;
			else if (button == 3)
				buttonText.color = Color.blue;
			else if (button == 2)
				buttonText.color = Color.red;
			else if (button == 1)
				buttonText.color = Color.green;
			else 
				buttonText.color = Color.black;

		} else if (go) {
			buttonText.color = Color.black;
			if (mash > 100)
				buttonText.text = "Yippie kay ay motherfucker";
			else if (mash > 75)
				buttonText.text = "Yee haw";
			else if (mash > 50)
				buttonText.text = "ok";
			else if (mash > 25)
				buttonText.text = "meh";
			else 
				buttonText.text = "You fucking suck";

			buttonText.text += "\r\nPress X to try again\r\nPress A to continue";
			cooldown += Time.deltaTime;
			if (cooldown > 1f) {
				if (Input.GetButtonDown ("X_button")) {
					buttonText.text = "Press X";
					start = false;
					go = false;
					go_time = 4f;
					game_time = 0;
					switch_time = 0;
					mash = 0;
				}
				if (Input.GetButtonDown ("A_button")) {
					Application.LoadLevel("Garden");
				}
			}
		}
	}
}