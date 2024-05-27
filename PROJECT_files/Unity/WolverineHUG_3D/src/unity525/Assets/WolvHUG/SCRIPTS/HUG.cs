using UnityEngine;
using System.Collections;

public class HUG : MonoBehaviour {
	public void Start () {
		AnimationEvent HUG;
		HUG = new AnimationEvent();
		HUG.functionName = "PrintEvent";
	}
	public void PrintEvent() {
		//Debug.Log ("PrintEvent");
	}

}
