using UnityEngine;
using System.Collections;
public class ChangeFollowTarget : MonoBehaviour {
[SerializeField] Transform[] FollowTargets;
UnityStandardAssets.Characters.ThirdPerson.AICharacterControl CharControl;
XMSEnemyHealth Char;
[SerializeField] float CountDeath=0;
[SerializeField] float MaxDeath=3;
bool isCounting=false;
int SelectedTarget=0;
float charHealth;
void Start(){
	Char=this.gameObject.GetComponent<XMSEnemyHealth>();
	CharControl= this.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
CharHealth=Char.XHealthXMS;
}
void Update () {
	if(CharHealth!=Char.XHealthXMS){
	CharHealth=Char.XHealthXMS;}
	}
public float CharHealth{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return charHealth;	
	}
    set { 
		charHealth = value;
	if(CountDeath<MaxDeath){
	if(charHealth<=20){
	isCounting=true;
		}	
if(isCounting){		
if(charHealth==100){
CountDeath++;
isCounting=false;
}	
		}
}
else{
	if(SelectedTarget<FollowTargets.Length-1){
	SelectedTarget++;
}
else{
	SelectedTarget=0;
}	
CharControl.SetTarget(FollowTargets[SelectedTarget]);
	CountDeath=0;
	isCounting=false;
}
}}
}