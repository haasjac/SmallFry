using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Peacock_Game : MonoBehaviour {

	Text buttonText;

	public float decrease_time = 0.5f;
	private float game_time = 0;
	private float switch_time = 0;
	private float d_time = 0;
	private int mash = 0;
	private int button = 1;

	// Use this for initialization
	void Start () {
		button = Mathf.FloorToInt(Random.Range (1, 4.99F));
		buttonText = GameObject.Find("/Canvas/ButtonText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		// Example of how to change GUI text
		buttonText.text = "Press A";

		if (game_time < 30) {
			if (game_time < switch_time) {
			} else {
				switch_time += Random.Range(1, 3);
				//print ("switch" + game_time);
				button = Mathf.FloorToInt(Random.Range (1, 4.99F));
				print (button + " " + game_time);
			}
			//print (button);
			if (Input.GetButtonDown ("Fire" + button)) {
					mash ++;
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
