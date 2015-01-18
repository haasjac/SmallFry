using UnityEngine;
using System.Collections;

public class pose : MonoBehaviour {

	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger ("Fish_anim", 2);
	}
}
