using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class XTimer : MonoBehaviour {
	public GameScoreDatabase GameScoreDB;
	public ScoreEntry score1 = new ScoreEntry ();
	public float Xtimer = 10f;
	public float XtimerMin = 1f;
	public float XtimerMax = 100f;
	public float cur_Xtimer;
	public float play_Xtimer;
	public float XtimerBarInitialScaleX = 1f;
	public Text XtimerTimeText;
	public bool XtimerTimeText_on = false;
	public  GameObject  XtimerGrapics;
	public Image XtimerBar;
	public bool XtimerActionSwitch = false;
	public bool XtimerIncreas = false;
	public bool XtimerOnIncreas = false;
	public bool XtimerIncreasTrigerON = false;
	public float XtimerIncreasTrigerValue = 2;
	public  GameObject XTimerActionObject;
	public bool XtimerPAUSE = false;
	public bool XtimerFunModeON = false;
	void Start () {
		cur_Xtimer = Xtimer;
		XtimerGrapics.SetActive (true);
		XtimerBarInitialScaleX = XtimerBar.transform.localScale.x;
		SetXtimerBar (); 
	}
	void Update () {
		if (!XtimerPAUSE){
		if (!XtimerIncreas){
			cur_Xtimer -= Time.deltaTime;
			SetXtimerBar (); 
					play_Xtimer+= Time.deltaTime;
			if ( XtimerFunModeON){
				XtimerMax = play_Xtimer;
				}
				if (XtimerTimeText_on){
					if ( XtimerFunModeON){
						XtimerTimeText.text = play_Xtimer.ToString ("00:00:00"); 
					}
					else{
				XtimerTimeText.text = cur_Xtimer.ToString ("f0");
					}
					}
				if (XtimerActionSwitch){
			if (!XtimerOnIncreas){
					if (XtimerIncreasTrigerON){
						XtimerIncreasTrigerON = false;
						cur_Xtimer += XtimerIncreasTrigerValue;
					}
					if ( cur_Xtimer <= XtimerMin ){
						if ( XtimerFunModeON){
				XTimerActionFun();

						} else {
XTimerAction();
						}
						} 
			}
				if (XtimerOnIncreas){
					if ( cur_Xtimer >= XtimerMax ){
						XTimerAction();
					}
			}
		}
		if (XtimerIncreas){
				cur_Xtimer += Time.deltaTime;

			if (XtimerActionSwitch){
				if (!XtimerOnIncreas){
						if (cur_Xtimer <= XtimerMin ){
							XTimerAction();
					}
				}
				if (XtimerOnIncreas){
						if (cur_Xtimer >= XtimerMax ){
							XTimerAction();
					}
				}
			}
		}
			}
	}
	}
	public void XtimerPAUSEmake(){
		if (!XtimerPAUSE) {
			XtimerPAUSE = true;
		}
		else  {XtimerPAUSE = false;}
	}
	public void XTimerAction(){	
		XtimerMax=play_Xtimer;
		XTimerActionObject.GetComponent<XMLmanager> ().setWriteModeON=false;
		XTimerActionObject.GetComponent<XMLmanager> ().SaveGameScore();
		Application.LoadLevel("End");
	}
	public void XTimerActionFun(){
		//Selected.Invoke (XTimerActionMake);
	cur_Xtimer=Xtimer;
	}
	public void SetXtimerBar()
	{
		float obj_Xtimer = (cur_Xtimer) * (XtimerBarInitialScaleX / Xtimer);
		XtimerBar.transform.localScale = new Vector3 (Mathf.Clamp (obj_Xtimer, 0f, XtimerBarInitialScaleX), XtimerBar.transform.localScale.y, XtimerBar.transform.localScale.z);
	}
	/*
	public class XTimerAct : MonoBehaviour, ISelectHandler {
	
		//public UnityEvent<XTimerAct> Selected;
		public UnityEvent Selected;
	[SerializeField]
		public XTimerAct context;
		public void onSelect(BaseEventData eventData){
			
			Debug.Log (this.gameObject.name + " was selected");
			Selected.Invoke(this);
			
		}
}
	*/
public void XtimerSpeedMode(){
	XtimerFunModeON=false;
}
public void XtimerFunMode(){
	XtimerFunModeON=true;
	Xtimer = 100f;
}
public float XtimerSaveTime(){
	if(XtimerFunModeON){
return play_Xtimer;
	}
	else{
		return play_Xtimer;
		//return Xtimer;
	}
}
}