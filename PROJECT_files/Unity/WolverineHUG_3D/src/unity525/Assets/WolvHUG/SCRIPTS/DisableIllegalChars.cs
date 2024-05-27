using UnityEngine;
using UnityEngine.UI;
using System;
public class DisableIllegalChars : MonoBehaviour {
[SerializeField] private InputField inputField;
string fromInput;
char[] illegalChars;
string Apostrophe = "'";
char Colon = ';';

	void Awake(){
		illegalChars = new char[] {'&','"',Apostrophe.ToCharArray()[0],'<',Colon,'>'};
	}
public	void Start () {
inputField.onValidateInput += ValidateInput;
	}
		public char ValidateInput(string text, int charIndex, char addedChar){
		for(int i=0; i<= illegalChars.Length-1;i++){
if (addedChar == illegalChars[i]){
	addedChar='\0';
}
	}
return addedChar;
	}
}
