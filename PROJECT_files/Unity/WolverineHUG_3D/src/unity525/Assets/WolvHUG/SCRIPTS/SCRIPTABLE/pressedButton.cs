using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "pressedButton", menuName = "ScriptableObjects/pressedButton")]

public class pressedButton : ScriptableObject {
public bool isPressed;
public string buttonName;
public void presse(){
	isPressed=true;
}
public void unpresse(){
	isPressed=false;
}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
