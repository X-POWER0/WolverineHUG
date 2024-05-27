using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ModeSwitch : MonoBehaviour {
public enum  ModeOn{
	SPEED,
	FUN
};
[SerializeField] private ModeOn _modeOn;
public  ModeOn SetModeOn{
	get { return _modeOn;}
    set { _modeOn = value;}
}
[SerializeField] private GameObject  ModeFun;
[SerializeField] private GameObject  ModeSpeed;
[SerializeField] private GameObject  ModeFunTxt;
[SerializeField] private GameObject  ModeSpeedTxt;
[SerializeField] private GameObject  Continue;
[SerializeField] private GameObject  Restart;
[SerializeField] private GameObject  ContinueTxt;
[SerializeField] private GameObject  RestartTxt;
[SerializeField] private GameObject  _menuButtonStart;
[SerializeField] private ExitMenu ExitMenuControls;
[SerializeField] private XTimer  xTimer;
public GameObject SetMenuButtonStart{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return _menuButtonStart;}
    set { _menuButtonStart = value;}

}
[SerializeField] private bool  _modeFunON=false;
public bool SetModeFunON{
	get { return _modeFunON;}
    set { _modeFunON = value;}
}
[SerializeField] private XMLmanager  PlayerData;
private int LastPlayerIndex=-1;

	string PlPref_SvName = "WolverineHUG_ScoreData";
	void Start () {
	_menuButtonStart = Continue;
			if(PlayerData.CheckSaveExist()){
			PlayerData.LoadGameScore();
		LastPlayerIndex = PlayerData.GameScoreDB.Score.Count - 1;
	if(LastPlayerIndex>=0){
		if (PlayerData.GameScoreDB.Score[LastPlayerIndex].mode=="FUN"){
_modeFunON=true;
ModeFun.SetActive(true);
ModeSpeed.SetActive(false);
ModeFunTxt.SetActive(true);
ModeSpeedTxt.SetActive(false);
ExitMenuControls.changeBtnByNumberInList(ModeFun.GetComponent<Button>(), 6);
_modeOn=ModeOn.FUN;
		}
		else if (PlayerData.GameScoreDB.Score[LastPlayerIndex].mode=="SPEED"){
_modeFunON=false;
ModeFun.SetActive(false);
ModeSpeed.SetActive(true);
ModeFunTxt.SetActive(false);
ModeSpeedTxt.SetActive(true);
ExitMenuControls.changeBtnByNumberInList(ModeSpeed.GetComponent<Button>(), 6);
_modeOn=ModeOn.SPEED;
		}
	}
	}
else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;				
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}

	if(CountScoreData>=0){
		if (PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="FUN"){
_modeFunON=true;
ModeFun.SetActive(true);
ModeSpeed.SetActive(false);
ModeFunTxt.SetActive(true);
ModeSpeedTxt.SetActive(false);
ExitMenuControls.changeBtnByNumberInList(ModeFun.GetComponent<Button>(), 6);
_modeOn=ModeOn.FUN;
}
else if (PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="SPEED"){
_modeFunON=false;
ModeFun.SetActive(false);
ModeSpeed.SetActive(true);
ModeFunTxt.SetActive(false);
ModeSpeedTxt.SetActive(true);
ExitMenuControls.changeBtnByNumberInList(ModeSpeed.GetComponent<Button>(), 6);
_modeOn=ModeOn.SPEED;
		}
	}
}
else{
		_modeOn=ModeOn.SPEED;
		_modeFunON=false;
ModeFun.SetActive(false);
ModeSpeed.SetActive(true);
ModeFunTxt.SetActive(false);
ModeSpeedTxt.SetActive(true);	
	}
	SetTimerMode();
	}
	public void SwitchMenuBtn(){
if(_modeFunON){
if(ModeSpeed.activeSelf){
	_menuButtonStart.SetActive(false);
	_menuButtonStart = Restart; 
_menuButtonStart.SetActive(true);
ContinueTxt.SetActive(false);
RestartTxt.SetActive(true);

}
else if(ModeFun.activeSelf){
	_menuButtonStart.SetActive(false);
	_menuButtonStart = Continue; 
_menuButtonStart.SetActive(true);
RestartTxt.SetActive(false);
ContinueTxt.SetActive(true);

}}
if(!_modeFunON){
if(ModeFun.activeSelf){
	_menuButtonStart.SetActive(false);
	_menuButtonStart = Restart; 
_menuButtonStart.SetActive(true);
ContinueTxt.SetActive(false);
RestartTxt.SetActive(true);
}
else if(ModeSpeed.activeSelf){
	_menuButtonStart.SetActive(false);
	_menuButtonStart = Continue; 
_menuButtonStart.SetActive(true);
RestartTxt.SetActive(false);
ContinueTxt.SetActive(true);

		}	
	}
	}

	public void SetTimerMode(){
if(_modeFunON){
xTimer.XtimerFunMode();
}
else if(!_modeFunON){
xTimer.XtimerSpeedMode();
}
	}
public void ChangeModeOn(){
if(_modeOn==ModeOn.FUN){_modeOn=ModeOn.SPEED;}else{_modeOn=ModeOn.FUN;
} 
}
	}
