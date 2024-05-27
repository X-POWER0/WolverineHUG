using UnityEngine;
using System.Collections;

public class ChangeFollowTargetPos : MonoBehaviour {
UnityStandardAssets.Characters.ThirdPerson.AICharacterControl CharControl;
XMSEnemyHealth Char;
[SerializeField] float CountDeath=0;
[SerializeField] float MaxDeath=3;
[SerializeField] Vector3 RespawnPosFROM;
[SerializeField] Vector3 RespawnPosTO;
Vector3 SpawnPos;
bool isCounting=true;
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
	SpawnPos=new Vector3 (Random.Range (RespawnPosFROM.x, RespawnPosTO.x), Random.Range (RespawnPosFROM.y, RespawnPosTO.y), Random.Range  (RespawnPosFROM.z, RespawnPosTO.z));
CharControl.target.position=SpawnPos;
	CountDeath=0;
	isCounting=false;
}
}}
}