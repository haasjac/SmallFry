using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OstrichMG_controller : MonoBehaviour {
	public static bool crouch_time;
	public static bool start = false;
	public float timer;
	public static bool win_condition;
	private float countdown;
	private Text scoreText;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		win_condition = false;
		countdown = timer;
		scoreText = GameObject.Find("/Canvas/CText").GetComponent<Text>();
		scoreText.text = "";
		scoreText.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		if (!OstrichMG_controller.start) {
			scoreText.text = "Press X to Start";
			if (Input.GetButtonDown("X_button"))
			    OstrichMG_controller.start = true;
		} else {
			scoreText.text = "Time until hiding: " + countdown;
			countdown -= Time.deltaTime;
			//print (countdown);
			OstrichMG_controller.crouch_time = false;
			if (countdown < 1f)
				animator.SetInteger ("anim", 1);
			else
				animator.SetInteger ("anim", 0);
			if (countdown < 0.1f) {
				OstrichMG_controller.crouch_time = true;
				countdown = timer;
			}
		}
	}
}
