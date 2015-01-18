using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class respawn : MonoBehaviour {
		private float x;
		private float y;
		private Vector3 polePosition;
		private GameObject poleObj;
		// Use this for initialization

		void Start () {
			x = transform.position.x;
			y = transform.position.y;
		}

		void OnCollisionEnter2D(Collision2D coll) {
			if (coll.gameObject.tag == "Respawn") {
				Debug.Log("Respawn");
				Vector3 pos = new Vector3(x,y,0f);
				transform.position = pos;
				if (GlobalState.instance.fishingRodGet) {
					GlobalState.instance.fishingRodGet = false;
					poleObj.renderer.enabled = true;
					poleObj.GetComponent<BoxCollider2D>().enabled = true;
				}
			}

			if (coll.gameObject.tag == "Pole") {
				Debug.Log("Got pole");
				poleObj = coll.gameObject;
				poleObj.renderer.enabled = false;
				poleObj.GetComponent<BoxCollider2D>().enabled = false;
				GlobalState.instance.fishingRodGet = true;
			}
		}
	}
}
