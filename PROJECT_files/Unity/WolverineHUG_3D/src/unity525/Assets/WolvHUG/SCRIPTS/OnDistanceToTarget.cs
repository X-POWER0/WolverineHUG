using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets;
public class OnDistanceToTarget : MonoBehaviour {
	public Transform Target;
	Transform Char;
	float Distance;
	bool FarPlaying = false;
	bool NearPlaying = false;
	public float FarDistance = 25.0f;
	public float NearDistance = 4.0f;
	public float WolvNearDistance = 16.0f;
	
AudioClipsList SoundsList;
	List<AudioClip> FarDistSounds = new List <AudioClip>();
	List<AudioClip> NearDistSounds = new List <AudioClip>();
	AudioSource CharAudioSource;
	[SerializeField] GameObject WolvHear;
	float DistanceWolv; 
	void Start () {
SoundsList = GameObject.FindGameObjectWithTag("AudioList").GetComponent<AudioClipsList>();
		Char = this.transform;
	FarDistSounds = SoundsList.FarDistSounds;
	NearDistSounds = SoundsList.NearDistSounds;
		CharAudioSource = this.GetComponent<AudioSource>();
	}
	
	IEnumerator  StopSoundAfterTime(AudioSource AudioPlayer, float delayTime){
		yield return new WaitForSeconds(delayTime);		
		StopSound(AudioPlayer);
	}
	IEnumerator PlayFromListAfterTime(AudioSource AudioPlayer,List<AudioClip> AudioClips,  float EndSoundIn, float delayTime){
		yield return new WaitForSeconds(delayTime);		
		int MaxCount = 0;
		MaxCount = AudioClips.Count; 
		int random = Random.Range (0,MaxCount);
		PlaySound(AudioPlayer,AudioClips[random], EndSoundIn);
	}
	private void StopSound(AudioSource AudioPlayer){
		AudioPlayer.Stop ();
		NearPlaying = false;
		FarPlaying = false;
	}
	private void PlaySound(AudioSource AudioPlayer,AudioClip AudioClp, float EndSoundIn ){
		AudioPlayer.clip = AudioClp;
		AudioPlayer.Play ();
		StartCoroutine (StopSoundAfterTime(AudioPlayer, EndSoundIn));
	}
	void Update () {
		DistanceWolv= Vector3.Distance(WolvHear.transform.position, Char.position);
		if(DistanceWolv<WolvNearDistance && CharAudioSource.mute){
CharAudioSource.mute=false;
		}
				if(DistanceWolv>WolvNearDistance){
CharAudioSource.mute=true;
		}
		Distance = Vector3.Distance(Target.position, Char.position);
		if(Distance>NearDistance){
			if(!FarPlaying){
			FarPlaying = true;
			StartCoroutine (PlayFromListAfterTime(CharAudioSource,FarDistSounds, 3f, 2f));
			}
		}
		if(Distance<NearDistance){
			if(!NearPlaying){
				NearPlaying = true;
			StartCoroutine (PlayFromListAfterTime(CharAudioSource,NearDistSounds, 3f, 2f));
			}
		}
		}
		public void SetWolvHear(GameObject gb){
			WolvHear=gb;
		}
}