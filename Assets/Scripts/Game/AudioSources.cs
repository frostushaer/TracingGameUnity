using UnityEngine;
using System.Collections;

public class AudioSources : MonoBehaviour {

	/// The loading canvas instance.
	public static AudioSources instance;

	/// The audio sources.
	[HideInInspector]
	public AudioSource [] audioSources;

	/// The bubble sound effect.
	public AudioClip bubbleSFX;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
			audioSources = GetComponents<AudioSource>();
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void PlayBubbleSFX(){
		if (bubbleSFX != null && audioSources[1] != null) {
			CommonUtil.PlayOneShotClipAt (bubbleSFX, Vector3.zero, audioSources[1].volume);
		}

	}
}
