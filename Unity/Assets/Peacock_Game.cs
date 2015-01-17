using UnityEngine;
using System.Collections;

public class Peacock_Game : MonoBehaviour {

	public float decrease_time = 0.25f;
	public float Time_of_Game = 5f;
	private float game_time = 0;
	private float switch_time = 0;
	private float d_time = 0;
	private int mash = 0;
	private int button = 1;

	// Use this for initialization
	void Start () {
		button = Mathf.FloorToInt(Random.Range (1, 4.99F));
	}
	
	// Update is called once per frame
	void Update () {
		if (game_time < Time_of_Game) {
			if (game_time < switch_time) {
			} else {
				switch_time += Random.Range(1, 3);
				//print ("switch" + game_time);
				button = Mathf.FloorToInt(Random.Range (1, 4.99F));
				print (button + " " + game_time);
			}
			//print (button);
			if (Input.GetButtonDown ("Fire" + button)) {
					mash += 3;
			}
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2") || 
			    Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire4")) {
				mash --;
			}
			game_time += Time.deltaTime;

			if (d_time > decrease_time) {
				d_time = 0;
				mash --;
			}
			d_time += Time.deltaTime;
		} else {
			print ("done " + mash);
		}

	}
}
