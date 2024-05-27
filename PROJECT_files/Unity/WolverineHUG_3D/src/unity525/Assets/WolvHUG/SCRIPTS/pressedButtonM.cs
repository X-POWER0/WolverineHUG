using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pressedButtonM : MonoBehaviour {
public bool isPressed;
public string buttonName;
public void presse(){
	isPressed=true;
}
public void unpresse(){
	isPressed=false;
}
}
