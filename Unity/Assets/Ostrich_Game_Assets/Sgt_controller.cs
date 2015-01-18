using UnityEngine;
using System.Collections;
namespace SpaceJam{
public class Sgt_controller : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			if (OstrichMG_controller.crouch_time) {
			//Vector3 pos = 
				}

			if ( (transform.position.x - OstrichMG_player.playersPOS)  < 1) {
				Vector3 pos = transform.position;
				pos.x +=  2 * speed;
				transform.position = pos;
			} 
			
			else if ((transform.position.x - OstrichMG_player.playersPOS)  > 1)  {
				Vector3 pos = transform.position;
				pos.x += 0.5f * speed;
				transform.position = pos;	
			}
			
		}
}
}
