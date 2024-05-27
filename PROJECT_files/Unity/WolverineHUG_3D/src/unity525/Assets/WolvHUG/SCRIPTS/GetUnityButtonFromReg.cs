
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.Win32;
//using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

	[System.Serializable]
		public class MyException : System.Exception
		{
			public MyException() {
			 }
			public MyException(string message) : base(message) { 
			}
			public MyException(string message, System.Exception inner) : base(message, inner) { 
			}
			protected MyException(
				System.Runtime.Serialization.SerializationInfo info,
				System.Runtime.Serialization.StreamingContext context) : base(info, context) { 
				}
		}
public class GetUnityButtonFromReg : MonoBehaviour {
	public static string LoadLinuxPlayerPref(string keypath, string btnValName){
		string textBtn="HUG";
		//if (File.Exists (keypath)) 
		if(PlayerPrefs.GetString (btnValName)!=""){
   textBtn = PlayerPrefs.GetString (btnValName);
		}
		return textBtn;
	}
	public static string LoadRegVal(string keypath, string btnValName){
		string textBtn="HUG";
		if(Application.platform!=RuntimePlatform.WindowsPlayer || Application.platform!=RuntimePlatform.WindowsEditor){
		try{
			
			using (RegistryKey key =Registry.CurrentUser.OpenSubKey(keypath, false))
			if(key  != null){
				
				var keyValues=key.GetValueNames();
				foreach(var valueName in keyValues){
					if (valueName.ToString().Contains(btnValName)){
			var val = Encoding.UTF8.GetString(key.GetValue(valueName.ToString())as byte[]);
			
			if (!string.IsNullOrEmpty(val))
			{
				textBtn = val.ToString();	}
					}
				}
			}
			
		}
		catch (MyException ex) 
		{
			return  textBtn;
		}
	}
		return   textBtn;
	}
}
