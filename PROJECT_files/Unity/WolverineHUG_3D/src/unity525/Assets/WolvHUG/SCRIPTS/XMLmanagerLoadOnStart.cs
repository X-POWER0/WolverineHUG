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

public class XMLmanagerLoadOnStart : MonoBehaviour {
	public Text XMLScoreREAD;
	public Text XMLPlayerNameREAD;
	public Text XMLDateREAD;
	public Text XMLModeREAD;
	public Text XMLTimeREAD;
	bool XMLsaveFileExist = true;
	string PlPref_SvName = "WolverineHUG_ScoreData";
	public static XMLmanagerLoadOnStart ins;
	void Awake (){
		ins = this;
	}
	public GameScoreDatabase GameScoreDB;
	public void LoadGameScore(){
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
			FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml", FileMode.Open);
			GameScoreDB = serializer.Deserialize (stream) as GameScoreDatabase;
			stream.Close ();
XMLsaveFileExist = true;
		} else {
XMLsaveFileExist = false;
			Debug.Log("No FILE");
		}
	}
	void Start () {   
		ScoreEntry Score = new ScoreEntry ();
		GameScoreDB.Score.Add (Score);
		LoadGameScore();
		if(XMLsaveFileExist){
		XMLScoreREAD.text = GameScoreDB.Score[0].score.ToString("000") ;
		XMLDateREAD.text = GameScoreDB.Score[0].date.ToString() ;
		XMLTimeREAD.text = GameScoreDB.Score[0].time.ToString() ;
		XMLModeREAD.text = GameScoreDB.Score[0].mode.ToString() ;
		XMLPlayerNameREAD.text = GameScoreDB.Score[0].PlayerName;
		}
else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;				
while (PlayerPrefs.GetInt(PlPref_SvName+CountScoreData.ToString())==1){
CountScoreData +=1;
}
XMLScoreREAD.text = PlayerPrefs.GetFloat(PlPref_SvName+CountScoreData.ToString()+"_score").ToString("000");
		XMLDateREAD.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_date") ;
		XMLTimeREAD.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_time") ;
		XMLModeREAD.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode") ;
		XMLPlayerNameREAD.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name") ;
		
}
	
	}
}