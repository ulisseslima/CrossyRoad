using UnityEngine;
using System.Collections;

public class SoundManagerController : MonoBehaviour {
	public AudioClip scoreClip;

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManagerController instance = null;
	
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;
	
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	public void Play(AudioClip clip){
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	public void PlayScoreMod10() {
		sfxSource.clip = scoreClip;
		sfxSource.Play ();
	}
	
	public void RandomizeSfx(params AudioClip[] clips){
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		
		sfxSource.pitch = randomPitch;
		sfxSource.clip = clips [randomIndex];
		sfxSource.Play ();
	}
}
