using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class HoverBTN : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler {
	AudioClipsList MenuSounds;
	AudioSource MenuAudioSource;
	AudioClip MenuHover;
	AudioClip MenuClick;
	bool PlayingHoverSound = false;
	bool PlayingClickSound = false;
	void OnEnable(){
		MenuSounds = GameObject.FindGameObjectWithTag("MenuSounds").GetComponent<AudioClipsList>() ;
		MenuAudioSource = GameObject.FindGameObjectWithTag("MenuSounds").GetComponent<AudioSource>() ;
		MenuHover = MenuSounds.SoundsOther[0];
		MenuClick = MenuSounds.SoundsOther[1];
	}
public string HoverFxTarget;
public GameObject HovObjFxTarget;
public Color HovFxTcolorBase;
public Color HovFxTcolorHovered;

void OnMouseEnter(){
HovObjFxTarget.GetComponent<Text>().color = HovFxTcolorHovered;
		if(!PlayingHoverSound){
			PlayingHoverSound = true;
			MenuAudioSource.clip = MenuHover;
			MenuAudioSource.Play();
		}
	}

void OnMouseExit(){
HovObjFxTarget.GetComponent<Text>().color = HovFxTcolorBase;
}
	void OnMouseClick(){
		if(!PlayingClickSound){
			PlayingClickSound = true;
			MenuAudioSource.clip = MenuClick;
			MenuAudioSource.Play();
		}
		else if(PlayingClickSound){
			StopSound(MenuAudioSource,PlayingClickSound);
			MenuAudioSource.clip = MenuClick;
			MenuAudioSource.Play();
		}
	}
	private void StopSound(AudioSource AudioPlayer,bool SelectBool){
		PlayingHoverSound = false;
	}
	IEnumerator  StopSoundAfterTime(AudioSource AudioPlayer,bool SelectBool, float delayTime){
		yield return new WaitForSeconds(delayTime);		
		StopSound(AudioPlayer,SelectBool);
	}
public void OnPointerEnter(PointerEventData eventData){
HovObjFxTarget.GetComponent<Text>().color = HovFxTcolorHovered;
		if(!PlayingHoverSound){
			PlayingHoverSound = true;
			MenuAudioSource.clip = MenuHover;
			MenuAudioSource.PlayOneShot(MenuHover);
		}
		else if(PlayingHoverSound){
			StopSound(MenuAudioSource,PlayingHoverSound);
			MenuAudioSource.clip = MenuHover;
			MenuAudioSource.PlayOneShot(MenuHover);
		}
}
public void OnPointerExit(PointerEventData eventData){
HovObjFxTarget.GetComponent<Text>().color = HovFxTcolorBase;
}
	public void OnPointerClick(PointerEventData eventData){
		HovObjFxTarget.GetComponent<Text>().color = HovFxTcolorBase;
		if(!PlayingClickSound){
			PlayingClickSound = true;
			MenuAudioSource.clip = MenuClick;
			MenuAudioSource.Play();
		}
	}

}
