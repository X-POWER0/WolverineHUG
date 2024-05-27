using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour {
	[SerializeField] AudioSource MenuSoundsPlay;
[SerializeField]  AudioClipsList MenuClips;
	AudioClip MenuHover;
	AudioClip MenuClick;
	void Start () {
	 MenuHover = MenuClips.SoundsOther[0];
	MenuClick = MenuClips.SoundsOther[1];
	}
	void Update () {
	
	}
}
