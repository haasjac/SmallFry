using UnityEngine;
using System.Collections;

public class Block_Move : MonoBehaviour {
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	// Update is called once per frame
	void Update () {
		i += Random.Range(2, 9);

		if (i % 2 == 0 && i > 1500) {
			Vector3 pos = transform.position;
			if (i % 4 == 0) pos.x -=2;
			else pos.x += 2;
			transform.position = pos;
			i=0;
		}
	}
}
