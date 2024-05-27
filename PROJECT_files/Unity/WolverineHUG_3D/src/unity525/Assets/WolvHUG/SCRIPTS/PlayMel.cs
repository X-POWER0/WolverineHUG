using UnityEngine;
using System.Collections;

public class PlayMel : MonoBehaviour {
	AudioClipsList MenuSounds;
	AudioSource MainAudioSource;
	AudioClip Melody;
	AudioClip Main;
	bool PlayingHoverSound = false;
	bool PlayingClickSound = false;
	void OnEnable(){
		MenuSounds = GameObject.FindGameObjectWithTag("MenuSounds").GetComponent<AudioClipsList>() ;
		MainAudioSource = GameObject.FindGameObjectWithTag("AudioMain").GetComponent<AudioSource>() ;
		Melody = MenuSounds.SoundsOther[2];
		Main = MenuSounds.SoundsOther[3];
	}
	public void PlayMelody(){
		MainAudioSource.clip = Main;
		MainAudioSource.Stop ();
		MainAudioSource.clip = Melody;
		MainAudioSource.Play ();
	}
	public void OFFPlayMelody(){
		MainAudioSource.clip = Melody;
		MainAudioSource.Stop ();
		MainAudioSource.clip = Main;
		MainAudioSource.Play ();
	}
}