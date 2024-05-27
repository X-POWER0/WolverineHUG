using UnityEngine;
using System.Collections;
public class ControledTargetBlood : MonoBehaviour {
[SerializeField] XMSEnemyHealth CharHelth;
[SerializeField] bool MakeAfterKillFx=false;
bool CheckDeath = false;
float Timer=0;
float TimerRate=0.1f;
	void Update () {
if(MakeAfterKillFx){
	if(CharHelth.XHealthXMS<100){
CheckDeath = true;
	}
	if(CheckDeath){
		if(CharHelth.XHealthXMS>80){
			if(Timer<Time.time){
				Timer = Time.time+(TimerRate*Time.deltaTime*10);
			}
		else if(Timer-((TimerRate*Time.deltaTime*10)*0.5)<Time.time){
		CharHelth.MakeDeathParticle();
	CheckDeath=false;
	Timer=Time.time;
		}
			}	
	}		
	}
		}
		public void SetMakeAfterKillFx(bool bl){
			MakeAfterKillFx=bl;
		}
}