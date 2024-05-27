using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class XPlayers : MonoBehaviour {
	public GameScoreDatabase GameScoreDB;
	public float XPlayersCount;
	public float XPlayerUniqID;
	public string XPlayerName = "";
	public ArrayList[] XPlayerNames;
	public ArrayList[] XPlayerChosen;
	public string XPlayerChosenName;
	public string XPlayerChosenUniqID;
	private int LastPlayerIndex;
	public bool XPlayerObjectON = true;
	public GameObject XPlayerObject;
	public Text XPlayerNameText;
	public Text XPlayerNameTextTake;
	public bool XPlayerNameTextTakeON =  true;
	public bool XPlayerNameTextON =  true;
	public bool XPlayerNameLoadON =  true;
	public bool XPlayerNameSaveON =  true;
	public bool XPlayerPlPrefON =  false;
	string PlPref_SvName = "WolverineHUG_ScoreData";
	void Start () {
		if (XPlayerNameLoadON) {
			XPlayerNameSet ();
		}		
	}
	public void XPlayerChoose () {
		ScoreEntry Score = new ScoreEntry ();
		if(XPlayerObject.GetComponent<XMLmanager> ().CheckSaveExist()){
		if (GameScoreDB.Score.Count != 0) {
			LastPlayerIndex = GameScoreDB.Score.Count - 1;
			//Debug.Log (LastPlayerIndex);
			XPlayerChosenName = GameScoreDB.Score [LastPlayerIndex].PlayerName;
			XPlayerNameText.text = XPlayerChosenName.ToString ();
		}	
		}
		else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1 && XPlayerPlPrefON){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
XPlayerChosenName = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
		XPlayerNameText.text = 	XPlayerChosenName.ToString ();	
		}
	}	
	public void XPlayerNameSet () {
		
		if (XPlayerNameLoadON) {
		if(XPlayerObject.GetComponent<XMLmanager> ().CheckSaveExist()){
			XPlayerObject.GetComponent<XMLmanager> ().LoadGameScore ();
			GameScoreDB.Score = XPlayerObject.GetComponent<XMLmanager> ().GameScoreDB.Score;
			if (GameScoreDB.Score.Count != 0) {
				LastPlayerIndex = GameScoreDB.Score.Count - 1;
				XPlayerName = XPlayerObject.GetComponent<XMLmanager> ().GameScoreDB.Score[LastPlayerIndex].PlayerName;
			}
		}
		else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1 && XPlayerPlPrefON){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
XPlayerName =  PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
		}
		}		
		if (XPlayerName == "") {
			if (XPlayerNameTextTakeON){
				XPlayerName = XPlayerNameTextTake.text;}
			else if(XPlayerNameTextON){
				XPlayerName = XPlayerNameText.text;
			}
			else{
				XPlayerName = "WOLVERINE";}
		}
		if (XPlayerName != "") {
			if (XPlayerNameTextON){
				XPlayerNameText.text = XPlayerName;}
		}
		if (XPlayerNameSaveON) {
			XPlayerObject.GetComponent<XMLmanager> ().SaveGameScore ();
		if(XPlayerObject.GetComponent<XMLmanager> ().CheckSaveExist()){
			ScoreEntry Score = new ScoreEntry ();
			GameScoreDB.Score.Add (Score);
			GameScoreDB.Score = XPlayerObject.GetComponent<XMLmanager> ().GameScoreDB.Score;
			if (GameScoreDB.Score.Count != 0) {
				LastPlayerIndex = GameScoreDB.Score.Count - 1;
				XPlayerName = GameScoreDB.Score [LastPlayerIndex].PlayerName;
			}
		}
		else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1 && XPlayerPlPrefON){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
XPlayerName =  PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
		}
		}
		XPlayerChosenName = XPlayerName;
	}
		//TODO make furthere XPlayerChosen = XPlayerName, XPlayerUniqID;
}