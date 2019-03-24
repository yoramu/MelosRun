using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {
	public Transform spike;
	public string playerTag = "Player";
	public float activeDuration = 2f;
	public float inactiveDuration = 2f;
	public bool startActive = true;
	public bool randomize = false;
	private bool isActive;
	[SerializeField] private AudioClip stabSound;
	[SerializeField] private AudioClip putSound;
	private AudioSource audioSource;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		if (startActive) {
			SetActive ();
		} else {
			SetInactive ();
		}
	}

	void SetActive () {
		float duration = activeDuration;
		isActive = true;
		spike.gameObject.SetActive (true);
		audioSource.PlayOneShot (stabSound);
		if (randomize) {
			duration = Random.Range (activeDuration * .75f, activeDuration * 1.25f);
		}
		Invoke ("SetInactive", duration);
	}

	void SetInactive () {
		float duration = activeDuration;
		isActive = false;
		spike.gameObject.SetActive (false);
		audioSource.PlayOneShot (putSound);
		if (randomize) {
			duration = Random.Range (inactiveDuration * .75f, inactiveDuration * 1.25f);
		}
		Invoke ("SetActive", duration);
	}

	public bool GetStatus () {
		return isActive;
	}
}