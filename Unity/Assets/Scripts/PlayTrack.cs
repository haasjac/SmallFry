using UnityEngine;
using System.Collections;

public class PlayTrack : MonoBehaviour {
	public AudioClip Track;
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (Track, transform.position);
	}

}
