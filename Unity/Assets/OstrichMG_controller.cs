using UnityEngine;
using System.Collections;

public class OstrichMG_controller : MonoBehaviour {
	public static bool crouch_time;
	public float timer;
	private float countdown;
	// Use this for initialization
	void Start () {
	countdown = timer;
	}
	
	// Update is called once per frame
	void Update () {
	
	countdown -= Time.deltaTime;
	//print (countdown);
	OstrichMG_controller.crouch_time = false;
		if (countdown < 1) {
			OstrichMG_controller.crouch_time = true;

			print("CROUCH TIME");
			countdown = timer;
		}
	}
}
