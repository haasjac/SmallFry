using UnityEngine;
using System.Collections;
using System;

public class Ostriches_run : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		//print ("Difference is : ");
		//print (Math.Abs (OstrichMG_player.playersPOS - transform.position.x));
		if (OstrichMG_player.playersPOS - transform.position.x > 5) {
			print ("Im behind you!");
			Vector3 pos = transform.position;
			pos.x += UnityEngine.Random.Range (3, 6) * speed;
			print (pos.x);
			transform.position = pos;
		}
		else if (OstrichMG_player.playersPOS - transform.position.x < 5)
		{
			print ("Im ahead! eat dirt!");
			Vector3 pos = transform.position;
			pos.x  +=  UnityEngine.Random.Range(0,3)* speed;
			print(pos.x);
			transform.position = pos;				
		}
	}
}
