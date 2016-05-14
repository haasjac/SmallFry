using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OstrichMG_controller : MonoBehaviour {
	public static bool crouch_time;
	public static bool start = false;
	public static bool lose = false;
	public float timer;
	public static bool win_condition;
	private float countdown;
	private Animator animator;
	private Behaviour can_move;
	SpriteRenderer Button;

	// Use this for initialization
	void Start () {
		lose = false;
		start = false;
		OstrichMG_controller.start = false;
		Button = GameObject.Find ("Sgt/Button").GetComponent<SpriteRenderer>();
		Button.GetComponent<Renderer>().enabled = false;
		animator = this.GetComponent<Animator>();
		win_condition = false;
		countdown = timer;
	}
	
	// Update is called once per frame
	void Update () {
		if (OstrichMG_controller.start && !lose) {
			countdown -= Time.deltaTime;
			//print (countdown);
			OstrichMG_controller.crouch_time = false;
			if (countdown < 1f)
				animator.SetInteger ("anim", 1);
			else
				animator.SetInteger ("anim", 0);
			if (countdown < 0.5f) {
				Button.GetComponent<Renderer>().enabled = true;
			} else {
				Button.GetComponent<Renderer>().enabled = false;
			}
			if (countdown < 0.1f) {
				OstrichMG_controller.crouch_time = true;
				countdown = timer;
			}
		}
	}
}
