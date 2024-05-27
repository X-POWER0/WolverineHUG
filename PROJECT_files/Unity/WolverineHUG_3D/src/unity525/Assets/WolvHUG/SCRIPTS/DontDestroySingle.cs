using UnityEngine;
using System.Collections;

public class DontDestroySingle : MonoBehaviour {
	public static DontDestroySingle instance {get; private set;}
	void Awake(){
	if(instance != null && instance != this){
			Destroy (this);
		}
		else{
			
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}
}
