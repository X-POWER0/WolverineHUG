using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XScore : MonoBehaviour {
public float XScoreHUGs;
public float XScoreKill;
public float XScoreHits;
//public GameObject XActorRecivScore;
	public float XScoreFull;
	public Text XScoreText;
	public bool XScoreTextON = true;
	public bool XScoreTrigerON = false;
	public bool XScoreTriger = false;
	public GameObject XScoreTrigerOwner;
	public bool ONXScoreTrigerOwner = true;
	float GameTimer = 0f;
	float AddTime = 0f;
	void Start () {
		if(ONXScoreTrigerOwner){
		GameTimer = XScoreTrigerOwner.GetComponent<XTimer>().Xtimer;
		}
	}
	/*
	public void onValueChanged(float XScoreFull)
	{
	}
*/
	void Update () {
XScoreFull = XScoreKill +  XScoreHUGs + XScoreHits;
		if (XScoreTrigerON) {
			if (XScoreTriger){
				if(ONXScoreTrigerOwner){
				XScoreTrigerOwner.GetComponent<XTimer> ().XtimerIncreasTrigerON = true;
					//TODO need to transfer in apropriate place not in enemy health just for now 
				AddTime = (GameTimer/XScoreTrigerOwner.GetComponent<XTimer>().cur_Xtimer) * 0.5f;
				if(AddTime>GameTimer*0.5f){
					AddTime = GameTimer/10f;
				}
				XScoreTrigerOwner.GetComponent<XTimer> ().cur_Xtimer += AddTime;
				}
			}
			XScoreTriger = false;
		}
	if (XScoreTextON) {
			XScoreText.text = XScoreFull.ToString ("000");
		}
	}
	public void clearXScore(){
		XScoreFull=0;
	}
}