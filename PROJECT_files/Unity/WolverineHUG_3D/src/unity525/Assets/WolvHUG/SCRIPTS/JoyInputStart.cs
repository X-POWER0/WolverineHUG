using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class JoyInputStart : MonoBehaviour {
[SerializeField]  ExitMenu MainMenu;
[SerializeField] GameObject InputTypePanel;
[SerializeField] private bool _joyInputON=false;
[SerializeField] private InputField inputField;
Array allKeyCodes;
public bool SetJoyInputON{
//c#7
//    get=> _selectedMenuButton;
//    set=> _selectedMenuButton = value;
	get { return _joyInputON;}
    set { _joyInputON = value;}
}
[SerializeField] private JoyText ObjToSetJoyOn;
string JoyCheckStr="";

    void Awake(){
allKeyCodes=System.Enum.GetValues(typeof(KeyCode));
}
	void Update () {
        if (Input.anyKey){
      KeyCode curKey= KeyCode.None;
foreach (KeyCode tempKey in allKeyCodes){
	if(Input.GetKeyDown(tempKey)){
		curKey=tempKey;
		if(tempKey.ToString().ToCharArray().Length>=4){
		JoyCheckStr=tempKey.ToString().Substring(0,3);
}
}
}
		if(JoyCheckStr.Contains("Joy"))	{
if(!_joyInputON){
_joyInputON=true;
InputTypePanel.SetActive(true);
ObjToSetJoyOn.SetJoyInputON=true;
MainMenu.enabled=false;
}}
		else if(JoyCheckStr.Contains("Ret"))	{
_joyInputON=false;
InputTypePanel.SetActive(false);
ObjToSetJoyOn.SetJoyInputON=false;
MainMenu.enabled=true;
}	
	}}
	public void CheckJoy(){
        if (Input.anyKey){
      KeyCode curKey= KeyCode.None;
foreach (KeyCode tempKey in allKeyCodes){
	if(Input.GetKeyDown(tempKey)){
		curKey=tempKey;
		string JoyCheckStr=tempKey.ToString().Substring(0,3);
		if(JoyCheckStr.Contains("Joy"))	{
if(!_joyInputON){
_joyInputON=true;
InputTypePanel.SetActive(true);
ObjToSetJoyOn.SetJoyInputON=true;
MainMenu.enabled=false;
}}}}}
	}	
}
