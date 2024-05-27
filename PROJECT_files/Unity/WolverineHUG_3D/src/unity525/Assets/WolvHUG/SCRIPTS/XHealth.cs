using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XHealth : MonoBehaviour {
public Image XHealthBar;
public GameObject XHealthUI;
public float max_XHealth = 100f;
public float min_XHealth = 0f;
public float cur_XHealth;
public bool ObjAlive = true;
public float XDoDmgAmount;
public GameObject XActorGetScore; 
public float XScoreKillAdd;
public Vector3 XHealthActorPosStrt;
	public Color FxColorDying;
	public Color FxColorBasic;
	public Vector3 XHealthActorPosSet;
	public GameObject XHealthModel;
	public GameObject blood;
	List<GameObject> bloodList= new List<GameObject>();
	public int bloodCount=0;
	public GameObject XDeadSign;
	void Start () {
XHealthActorPosStrt = this.gameObject.transform.position;
FxColorBasic = 	XHealthModel.gameObject.GetComponent<Renderer>().material.color;
ObjAlive = true;
cur_XHealth = max_XHealth;
SetXHealthBar ();
bloodList.Add(blood); 
	GameObject blood1 =	Instantiate (blood, blood.transform.position, Quaternion.identity ) as GameObject; 
	GameObject blood2 =	Instantiate (blood, blood.transform.position, Quaternion.identity ) as GameObject; 
	GameObject blood3 =	Instantiate (blood, blood.transform.position, Quaternion.identity ) as GameObject; 
bloodList.Add(blood1);
bloodList.Add(blood2);
bloodList.Add(blood3);
		blood.SetActive (false);
		blood1.SetActive (false);
		blood2.SetActive (false);
		blood3.SetActive (false);
//Damage by time
//invokeRepeating ("XDoDmg", 1f, 5f)
	}

void XDoDmg()
{
TakeXDmg (XDoDmgAmount);
}

public void TakeXDmg (float XDmgAmount)
{
		if(!ObjAlive){return;}
		else if (cur_XHealth <= 20) {
			XHealthModel.gameObject.GetComponent<Renderer>().material.color = FxColorDying;
		}
if(cur_XHealth <= 0){ 
cur_XHealth = 0;
ObjAlive = false;
ObjDie ();
}
cur_XHealth -= XDmgAmount;
		XHealthUI.SetActive (true);
		SetXHealthBar ();
	}
public void ObjDie() 
{
		XHealthUI.SetActive (false);
		Vector3 blodVec3;
		blodVec3 = new Vector3 (this.gameObject.transform.position.x, (this.gameObject.transform.position.y + 2f), this.gameObject.transform.position.z);
		bloodList[bloodCount].SetActive (false);
if(bloodCount< bloodList.Count-1){
bloodCount=+1;
}
else if(bloodCount>=bloodList.Count-1){
	bloodCount=0;
}
		bloodList[bloodCount].transform.position=blodVec3;
		bloodList[bloodCount].transform.rotation=Quaternion.identity;
		bloodList[bloodCount].SetActive (true);
		XDeadSign.SetActive (true);
		XHealthActorPosSet = this.gameObject.transform.position;
		this.gameObject.transform.position =  new Vector3(0, 0, 0);
XActorGetScore.GetComponent<XScore> ().XScoreKill += XScoreKillAdd;
		XHealthModel.gameObject.GetComponent<Renderer>().material.color = FxColorBasic;
		cur_XHealth = 200;
		ObjAlive = true;
}
	void Update () {
		if (cur_XHealth <= 0)
		{		
			ObjDie ();
		}
		}

public void SetXHealthBar()
{
float obj_XHealth = cur_XHealth / max_XHealth;
XHealthBar.transform.localScale = new Vector3 (Mathf.Clamp (obj_XHealth, 0f, 1f), XHealthBar.transform.localScale.y, XHealthBar.transform.localScale.z);
}
}