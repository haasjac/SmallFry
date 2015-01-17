using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OstrichMG_controller : MonoBehaviour {
	public static bool crouch_time;
	public float timer;
	private float countdown;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		countdown = timer;
		scoreText = GameObject.Find("/Canvas/CText").GetComponent<Text>();
		scoreText.text = "";
		scoreText.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Time: " + countdown;
		countdown -= Time.deltaTime;
		//print (countdown);
		OstrichMG_controller.crouch_time = false;
			if (countdown < 0.1f) {
				OstrichMG_controller.crouch_time = true;

				print("CROUCH TIME");
				countdown = timer;
		}
	}
}
