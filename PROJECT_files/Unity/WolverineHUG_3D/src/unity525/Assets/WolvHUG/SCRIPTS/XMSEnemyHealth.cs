using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XMSEnemyHealth : MonoBehaviour {
public int XHealthXMS = 100;
public GameObject XMSActorGetScore; 
public float XMSScoreKillAdd;
public Vector3 XMSEnemPosStrt;
public Vector3 XMSEnemPosSet;	

public Vector3	XMSEnemySpawnPosFROM  =  new Vector3(0, 1, 0);
public Vector3 XMSEnemySpawnPosTO =  new Vector3(150, 1, 100);

public Image XMSHealthBar;
public GameObject XMSHealthUI;
public float max_XMSHealth = 100f;
public float min_XMSHealth = 0f;
public float cur_XMSHealth;
public GameObject XMSHealthModel;
public Color XMSFxColorDying;
public Color XMSFxColorBasic;
public GameObject XMSDeadFX;
AudioSource WolvFXPlayer;
bool PlayingHurt = false;
public GameObject XMSDeadSign;
AudioClip Hurt;
AudioClip Die;
AudioClipsList SoundsList;
List<GameObject> XMSDeadFXList= new List<GameObject>();
int	XMSDeadFXCount=0;
	void Start () {
		//XMSEnemySpawnPosFROM  =  new Vector3(this.transform.position.x, 1, this.transform.position.z);
		WolvFXPlayer = GameObject.FindGameObjectWithTag("WolvAudioFX").GetComponent<AudioSource>();
		SoundsList = GameObject.FindGameObjectWithTag("AudioList").GetComponent<AudioClipsList>();
		Die = SoundsList.SoundFX[0];
		XMSFxColorBasic = XMSHealthModel.gameObject.GetComponent<Renderer>().material.color;
		XMSSetHealthBar ();

XMSDeadFXList.Add(XMSDeadFX); 
	GameObject XMSDeadFX1 =	Instantiate (XMSDeadFX, XMSDeadFX.transform.position, Quaternion.identity ) as GameObject; 
	GameObject XMSDeadFX2 =	Instantiate (XMSDeadFX, XMSDeadFX.transform.position, Quaternion.identity ) as GameObject; 
	GameObject XMSDeadFX3 =	Instantiate (XMSDeadFX, XMSDeadFX.transform.position, Quaternion.identity ) as GameObject; 
XMSDeadFXList.Add(XMSDeadFX1);
XMSDeadFXList.Add(XMSDeadFX2);
XMSDeadFXList.Add(XMSDeadFX3);
		XMSDeadFX.SetActive (false);
		XMSDeadFX1.SetActive (false);
		XMSDeadFX2.SetActive (false);
		XMSDeadFX3.SetActive (false);
	
		cur_XMSHealth = XHealthXMS;		
		}
void  Update ()
{
if (XHealthXMS<=0)
{
Dead();
}
}
public void ApplyDammage (int XMSDmg)
{
XHealthXMS -= XMSDmg;
		if(!PlayingHurt){
			PlayingHurt = true;
			Hurt = SoundsList.TargetSounds[0];
			this.GetComponent<AudioSource>().clip = Hurt;
		this.GetComponent<AudioSource>().Play();
		StartCoroutine (StopSoundAfterTime(this.GetComponent<AudioSource>(), 1f));
		}
			XMSDeadSign.SetActive (false);
		cur_XMSHealth = XHealthXMS;		
		XMSHealthUI.SetActive (true);
		XMSSetHealthBar ();
if (cur_XMSHealth <= 20) {
			XMSHealthModel.gameObject.GetComponent<Renderer>().material.color = XMSFxColorDying;
		}
}
	private void StopSound(AudioSource AudioPlayer){
		AudioPlayer.Stop ();
		PlayingHurt = false;
	}
	IEnumerator  StopSoundAfterTime(AudioSource AudioPlayer, float delayTime){
		yield return new WaitForSeconds(delayTime);		
		StopSound(AudioPlayer);
		PlayingHurt = false;
	}
public void Dead()
	{	WolvFXPlayer.clip = Die;
		WolvFXPlayer.Play();
		StartCoroutine (StopSoundAfterTime(WolvFXPlayer.GetComponent<AudioSource>(), 2f));
		Vector3 blodVec3;
		blodVec3 = new Vector3 (this.gameObject.transform.position.x, (this.gameObject.transform.position.y + 1f), this.gameObject.transform.position.z);

XMSDeadFXList[XMSDeadFXCount].SetActive (false);
if(XMSDeadFXCount< XMSDeadFXList.Count-1){
XMSDeadFXCount=+1;
}
else if(XMSDeadFXCount>=XMSDeadFXList.Count-1){
	XMSDeadFXCount=0;
}
		XMSDeadFXList[XMSDeadFXCount].transform.position=blodVec3;
		XMSDeadFXList[XMSDeadFXCount].transform.rotation=Quaternion.identity;
		XMSDeadFXList[XMSDeadFXCount].SetActive (true);
		XMSDeadSign.SetActive (true);
XMSHealthUI.SetActive (false);
		XMSActorGetScore.GetComponent<XScore> ().XScoreKill += XMSScoreKillAdd;
		XMSActorGetScore.GetComponent<XScore> ().XScoreTriger = true;

		XMSEnemPosSet = new Vector3 (Random.Range (XMSEnemySpawnPosFROM.x, XMSEnemySpawnPosTO.x), Random.Range (XMSEnemySpawnPosFROM.y, XMSEnemySpawnPosTO.y), Random.Range  (XMSEnemySpawnPosFROM.z, XMSEnemySpawnPosTO.z));
		XMSHealthModel.gameObject.GetComponent<Renderer>().material.color = XMSFxColorBasic;
		this.gameObject.transform.position = XMSEnemPosSet;
		XHealthXMS = 100;
		cur_XMSHealth = XHealthXMS;		
}
public void MakeDeathParticle(){
			Vector3 blodVec3;
		blodVec3 = new Vector3 (XMSEnemPosSet.x, (this.gameObject.transform.position.y+0.2f), XMSEnemPosSet.z);

XMSDeadFXList[XMSDeadFXCount].SetActive (false);
if(XMSDeadFXCount< XMSDeadFXList.Count-1){
XMSDeadFXCount=+1;
}
else if(XMSDeadFXCount>=XMSDeadFXList.Count-1){
	XMSDeadFXCount=0;
}
		XMSDeadFXList[XMSDeadFXCount].transform.position=blodVec3;
		XMSDeadFXList[XMSDeadFXCount].transform.rotation=Quaternion.identity;
		XMSDeadFXList[XMSDeadFXCount].SetActive (true);

}
	public void XMSSetHealthBar()
	{
		float obj_XHealth = cur_XMSHealth / max_XMSHealth;
		XMSHealthBar.transform.localScale = new Vector3 (Mathf.Clamp (obj_XHealth, 0f, 1f), XMSHealthBar.transform.localScale.y, XMSHealthBar.transform.localScale.z);
	}
}