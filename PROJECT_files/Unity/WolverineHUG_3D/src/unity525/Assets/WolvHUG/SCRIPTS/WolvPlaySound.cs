using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolvPlaySound : MonoBehaviour {
	AudioClip HugSound;
	AudioClip JumpSound;
	AudioClip HitSound;
	AudioSource WolvPlayerJump;
	AudioSource WolvPlayerHit;
	AudioClipsList AudioClipsHolder;
	AudioSource WolvPlayerHug;
	List <AudioSource> WolvPlayers = new List <AudioSource>();
	bool PlayingJumpSound = false;
	bool PlayingHitSound = false;
	bool PlayingHugSound = false;
	void Start () {
		AudioClipsHolder = GameObject.FindGameObjectWithTag("AudioList").GetComponent<AudioClipsList>();
		HugSound =AudioClipsHolder.WolvSounds[0];
		JumpSound =AudioClipsHolder.WolvSounds[2];
		HitSound =AudioClipsHolder.WolvSounds[0];
		AudioSource[] WolvAudioSources = this.GetComponents<AudioSource>();
		foreach(  AudioSource Audio in WolvAudioSources){
			WolvPlayers.Add (Audio);
		}
		WolvPlayerJump = WolvPlayers[0];
		WolvPlayerHit = WolvPlayers[1];
		WolvPlayerHug = WolvPlayers[2];

	}
	void Update () {
		if(Input.GetButtonDown("Jump") && Time.timeScale>0){
			if(!PlayingJumpSound){
				PlayingJumpSound = true;

				WolvPlayerJump.clip = JumpSound;
				WolvPlayerJump.Play();
			
				StartCoroutine (StopSoundAfterTime(WolvPlayerJump, 1f));
			}
			}		
			//not implemented Hit
		//if(Input.GetButtonDown("Fire1") && Time.timeScale>0){
		//	if(!PlayingHitSound){
		//		PlayingHitSound = true;
		//		WolvPlayerHit.clip = HitSound;
		//		WolvPlayerHit.Play();
		//		
		//		StartCoroutine (StopSoundAfterTime(WolvPlayerHit, 2f));
		//	}
		//}
		if(Input.GetButtonDown("Hug") && Time.timeScale>0){
			if(!PlayingHugSound){
				PlayingHugSound = true;
				
				WolvPlayerHug.clip = HugSound;
				WolvPlayerHug.Play();
				
				StartCoroutine (StopSoundAfterTime(WolvPlayerHug, 1f));
			}
		}
	}
	private void StopSound(AudioSource AudioPlayer){
		AudioPlayer.Stop ();
		PlayingJumpSound = false;
	}
	IEnumerator  StopSoundAfterTime(AudioSource AudioPlayer, float delayTime){
		yield return new WaitForSeconds(delayTime);		
		StopSound(AudioPlayer);
		PlayingJumpSound = false;
		PlayingHitSound = false;
		PlayingHugSound = false;
	}
}
