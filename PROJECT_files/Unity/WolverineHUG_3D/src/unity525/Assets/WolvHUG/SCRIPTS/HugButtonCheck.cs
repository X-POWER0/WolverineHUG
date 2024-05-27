using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Microsoft.Win32;
public class HugButtonCheck : MonoBehaviour {
bool Checked = false;
[SerializeField] Text ButtonDisplay;
[SerializeField] Text ButtonDisplay1;
[SerializeField] string filePath = "mainData";
[SerializeField] string FalseResult;
	void Start () {
	
			if(!Checked){
			//read file with assigned  input for Hug
			ButtonDisplay.text=GetUnityButtonKey(filePath); 
			ButtonDisplay1.text=GetUnityButtonKey(filePath); 
			Checked = true;
		}
	}
		
public string GetUnityButtonKey(string filePath){
	string fileData="";
	if(Application.platform==RuntimePlatform.WindowsPlayer || Application.platform==RuntimePlatform.WindowsEditor){
		string keypath = "SOFTWARE\\X-POWER\\WolverineHUG";
	string btnValName = "__Input Key PosHug";
			fileData=	GetUnityButtonFromReg.LoadRegVal(keypath,btnValName);
	}
	if(Application.platform==RuntimePlatform.LinuxPlayer){
		string keypath = "~/.config/unity3d/X-POWER/WolverineHUG/prefs";
	string btnValName = "__Input Key PosHug";
			fileData=	GetUnityButtonFromReg.LoadLinuxPlayerPref(keypath,btnValName);
	}
	if(fileData == "HUG" ){ 
	fileData = GetUnityButtonStringFromBinnary.LoadBytesFromFile(filePath);
	}
	if (fileData == null && fileData == ""){
fileData = FalseResult;
return fileData ;
	}else{
	return fileData ;
	}
}
}
