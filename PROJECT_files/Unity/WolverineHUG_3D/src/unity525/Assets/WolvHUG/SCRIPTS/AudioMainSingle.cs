using UnityEngine;
using System.Collections;

public class AudioMainSingle : MonoBehaviour {
	public static AudioMainSingle instance {get; private set;}
	private void Awake () {
		if(instance != null && instance != this){
			this.GetComponent<AudioSource>().Stop();
			Destroy (this);
		}
		else{
		instance = this;
		}}
	
}
