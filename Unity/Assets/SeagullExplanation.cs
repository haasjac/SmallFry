using UnityEngine;
using System.Collections;

namespace SpaceJam
{
	public class SeagullExplanation : MonoBehaviour
	{
		// Use this for initialization
		void Start()
		{
			Player_Movement.frozen = true;
		}
		
		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("X_button")) {
				Player_Movement.frozen = false;
				this.GetComponent<CanvasGroup>().alpha = 0.0f;
			}
		}
	}
}
