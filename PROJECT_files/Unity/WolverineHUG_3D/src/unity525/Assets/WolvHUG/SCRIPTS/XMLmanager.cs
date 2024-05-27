using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;
using UnityEngine.UI;
public class XMLmanager : MonoBehaviour {
	public float ScoreEntryCount = 0;
	public bool XMLWriteWritePnameeON = true;
public bool SetWritePnameeON{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return XMLWriteWritePnameeON;}
    set { XMLWriteWritePnameeON = value;}

}
	public GameObject XMLPlayerNameWriter;
	public bool XMLPlayerNameDefaultON = true;
	public Text XMLPlayerNameDefault;
	public bool XMLWriteWriteDateON = true;
	public bool XMLWriteSSScoreON = true;
	public GameObject XMLScoreWriter;
	public bool XMLwriteToSameIndexON = true;
	public bool XMLwriteToLastIndexON = true;
	public bool XMLmanagerLoadResultON = true;
[SerializeField] private bool XMLmanagerLoadModeON = false;
[SerializeField] private XTimer  xTimer;
	public Text XMLScoreREAD;
	public Text XMLPlayerNameREAD;
	public Text XMLDateREAD;
[SerializeField] private Text XMLPlayerTimeREAD;
	public bool XMLmanagerHighScoreON = false;
	private int HighScoreIndex;
	public Text XMLHighScoreREAD;
	public Text XMLHighPlayerNameREAD;
	public Text XMLHighDateREAD;
[SerializeField] private Text XMLHighPlayerTimeREAD;
	public bool XMLmanagerHighScore2ON = false;
	private int HighScore2Index;
	private int FunHighScore2Index;
	private int FunHighScoreIndex;
	public Text XMLHighScore2READ;
	public Text XMLHigh2PlayerNameREAD;
	public Text XMLHigh2DateREAD;
[SerializeField] private Text XMLHigh2PlayerTimeREAD;
	public bool XMLmanagerONload = false;
	private int LastScoreIndex;
	private int MaXscore;
	private int MaXscoreIndex;
	private int MaXscore2;
	private int MaXscore2Index;
	private int MaXmaxScore;
	public bool XMLshowScore = true;
	public bool XMLmanagerOLastPlayer = false;
[SerializeField] private bool XMLWriteWriteModeON = true;
	string PlPref_SvName = "WolverineHUG_ScoreData";
public bool setWriteModeON{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return XMLWriteWriteModeON;}
    set { XMLWriteWriteModeON = value;}

}
[SerializeField] private bool XMLWriteWriteTimeON = true;
[SerializeField] private ModeSwitch modeSwitch;
	//public string ScoreEntryName = "Score";
	public static XMLmanager ins;
	void Awake (){
		ins = this;
	}
	public GameScoreDatabase GameScoreDB;
			int CountScoreData = 0;

	public bool CheckSaveDirExist(){
	if (Directory.Exists (Application.dataPath + "/SAVE_DATA/SCORE")) {
		return true;
		}else{
			Debug.Log("ON_CHECK:No save Folder");
			return false;
			}
			}
	public bool CheckSaveExist(){
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
		return true;
		}else{
			Debug.Log("ON_CHECK:No save FILE");
			return false;
			}
	}	
	public void SaveGameScore(){
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		XMLWritePname ();
		XMLWriteSSScore ();
		XMLWriteDate ();
		XMLWriteMode();
		XMLWriteTime();
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml", FileMode.OpenOrCreate);
		serializer.Serialize (stream, GameScoreDB);
		stream.Close ();
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
		}else{
			Debug.Log("ON_SAVE:No save FILE Created, Trying PlayerPref");
			PlayerPrefSave();
		}
		}else{
			Directory.CreateDirectory(Application.dataPath + "/SAVE_DATA/SCORE");
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		XMLWritePname ();
		XMLWriteSSScore ();
		XMLWriteDate ();
		XMLWriteMode();
		XMLWriteTime();
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml", FileMode.OpenOrCreate);
		serializer.Serialize (stream, GameScoreDB);
		stream.Close ();
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
		}else{
			Debug.Log("ON_SAVE:No save FILE Created, Trying PlayerPref");
			PlayerPrefSave();
		}
		}else{
			Debug.Log("ON_SAVE:No save FILE Created, Trying PlayerPref");
			PlayerPrefSave();	}
		}
	}
	public void SaveNextGameScore(){
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		ScoreEntry Score = new ScoreEntry ();
		GameScoreDB.Score.Add (Score);
		XMLWritePname ();
		XMLWriteSSScore ();
		XMLWriteDate ();
		XMLWriteMode();
		XMLWriteTime();
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml", FileMode.OpenOrCreate);
		serializer.Serialize (stream, GameScoreDB);
		stream.Close ();
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
		}else{
			Debug.Log("ON_SAVE:No save FILE Created on SaveNext, Trying PlayerPref");
			PlayerPrefSaveNext();
			}
		}
		else{
			Directory.CreateDirectory(Application.dataPath + "/SAVE_DATA/SCORE");
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		ScoreEntry Score = new ScoreEntry ();
		GameScoreDB.Score.Add (Score);
		XMLWritePname ();
		XMLWriteSSScore ();
		XMLWriteDate ();
		XMLWriteMode();
		XMLWriteTime();
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml", FileMode.OpenOrCreate);
		serializer.Serialize (stream, GameScoreDB);
		stream.Close ();
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
		}else{
			Debug.Log("ON_SAVE:No save FILE Created on SaveNext, Trying PlayerPref");
			PlayerPrefSaveNext();
			}}
			else{
			Debug.Log("ON_SAVE:No save FILE Created on SaveNext, Trying PlayerPref");
			PlayerPrefSaveNext();
			}
		}

	}
	public void LoadGameScore(){
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml")) {
			FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/"+"score_data.xml", FileMode.Open);
			GameScoreDB = serializer.Deserialize (stream) as GameScoreDatabase;
			stream.Close ();
		} else {
		
			Debug.Log("ON_LOAD:No save FILE");
		}
		}else
		{
			PlayerPrefLoad();
		}
	}
	// Use this for initialization
	void Start () {
		if (XMLmanagerONload) {
			if(CheckSaveExist()){
			LoadGameScore();
			}
			if(XMLmanagerOLastPlayer){
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
			if(CheckSaveExist()){
				if(GameScoreDB.Score.Count != 0){
					LastScoreIndex = GameScoreDB.Score.Count - 1;
					if(GameScoreDB.Score [LastScoreIndex].PlayerName != ""){
					XMLPlayerNameDefault.text = GameScoreDB.Score [LastScoreIndex].PlayerName;
					}
					}
			}
			else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
					if(PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name") != ""){
			XMLPlayerNameDefault.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
					}
			}
			}else{
if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){	
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
					if(PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name") != ""){
			XMLPlayerNameDefault.text = PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
					}
			}
			}
			}
		}
		if (XMLmanagerLoadResultON) {
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
			if(CheckSaveExist()){
			LoadGameScore();
			if(GameScoreDB.Score.Count != 0){
			LastScoreIndex = GameScoreDB.Score.Count - 1;
				if(XMLshowScore){
				XMLScoreREAD.text = GameScoreDB.Score[LastScoreIndex].score.ToString("000") ;
				XMLDateREAD.text = GameScoreDB.Score[LastScoreIndex].date;
				XMLPlayerNameREAD.text = GameScoreDB.Score[LastScoreIndex].PlayerName;
				XMLPlayerTimeREAD.text = GameScoreDB.Score[LastScoreIndex].time;
				}
				}
			}
else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
				if(XMLshowScore){
	XMLScoreREAD.text = 
				PlayerPrefs.GetInt(PlPref_SvName+CountScoreData.ToString()+"_score").ToString("000");
				XMLDateREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_date");
				XMLPlayerNameREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
				XMLPlayerTimeREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_time");
				}

}
}else{
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
				if(XMLshowScore){
	XMLScoreREAD.text = 
				PlayerPrefs.GetInt(PlPref_SvName+CountScoreData.ToString()+"_score").ToString("000");
				XMLDateREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_date");				
				XMLPlayerNameREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_name");
				XMLPlayerTimeREAD.text = 
				PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_time");
				}
}
}
}
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
		ScoreEntry Score = new ScoreEntry ();
		GameScoreDB.Score.Add (Score);}
		else{			
			if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){	
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
if(PlayerPrefs.GetString(PlPref_SvName+(CountScoreData).ToString()+"_time")!="")
			CountScoreData+=1;
			}
		}
		if (XMLmanagerHighScoreON){
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
			if(CheckSaveExist()){
			LoadGameScore();
			LastScoreIndex = GameScoreDB.Score.Count - 1;
			if(	GameScoreDB.Score[LastScoreIndex].mode=="SPEED")
			{
			HighScoreIndex = FindMaxScore(GameScoreDB.Score);
			XMLHighScoreREAD.text = GameScoreDB.Score[HighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = GameScoreDB.Score[HighScoreIndex].date;
			XMLHighPlayerNameREAD.text = GameScoreDB.Score[HighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = GameScoreDB.Score[HighScoreIndex].time;
			if (XMLmanagerHighScore2ON){    
				HighScore2Index = FindMaxScore2(GameScoreDB.Score);
				XMLHighScore2READ.text = GameScoreDB.Score[HighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = GameScoreDB.Score[HighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = GameScoreDB.Score[HighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = GameScoreDB.Score[HighScore2Index].time;
			}
		}
		
			if(	GameScoreDB.Score[LastScoreIndex].mode=="FUN")
			{
			FunHighScoreIndex = FindMaxFUNScore(GameScoreDB.Score);
			XMLHighScoreREAD.text = GameScoreDB.Score[FunHighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = GameScoreDB.Score[FunHighScoreIndex].date;
			XMLHighPlayerNameREAD.text = GameScoreDB.Score[FunHighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = GameScoreDB.Score[FunHighScoreIndex].time;
			if (XMLmanagerHighScore2ON){    
				FunHighScore2Index = FindFUNMaxScore2(GameScoreDB.Score);
				XMLHighScore2READ.text = GameScoreDB.Score[FunHighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = GameScoreDB.Score[FunHighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = GameScoreDB.Score[FunHighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = GameScoreDB.Score[FunHighScore2Index].time;
			}
			}
		}
		else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
			if( PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="SPEED")
			{
				List<ScoreEntry> ScoreList = new List<ScoreEntry>();
				ScoreList = PlayerPrefList();
			HighScoreIndex = FindMaxScore(ScoreList);
			XMLHighScoreREAD.text = ScoreList[HighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = ScoreList[HighScoreIndex].date;
			XMLHighPlayerNameREAD.text = ScoreList[HighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = ScoreList[HighScoreIndex].time;			
			if (XMLmanagerHighScore2ON){    
				List<ScoreEntry> ScoreList2 = new List<ScoreEntry>();
				ScoreList2 = PlayerPrefList();
				HighScore2Index = FindMaxScore2(ScoreList2);
				XMLHighScore2READ.text = ScoreList2[HighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = ScoreList2[HighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = ScoreList2[HighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = ScoreList2[HighScore2Index].time;
			}
		}
		if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
						if(	PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="FUN")
			{
				List<ScoreEntry> ScoreList3 = new List<ScoreEntry>();
				ScoreList3 = PlayerPrefList();
			FunHighScoreIndex = FindMaxFUNScore(ScoreList3);
			XMLHighScoreREAD.text = ScoreList3[FunHighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = ScoreList3[FunHighScoreIndex].date;
			XMLHighPlayerNameREAD.text = ScoreList3[FunHighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = ScoreList3[FunHighScoreIndex].time;
			if (XMLmanagerHighScore2ON){  
				List<ScoreEntry> ScoreList4 = new List<ScoreEntry>();
				ScoreList4 = PlayerPrefList(); 
				FunHighScore2Index = FindFUNMaxScore2(ScoreList4 );
				XMLHighScore2READ.text = ScoreList4[FunHighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = ScoreList4[FunHighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = ScoreList4[FunHighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = ScoreList4[FunHighScore2Index].time;
			}
			}
		}
		}else{
if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
			if( PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="SPEED")
			{
				List<ScoreEntry> ScoreList = new List<ScoreEntry>();
				ScoreList = PlayerPrefList();
			HighScoreIndex = FindMaxScore(ScoreList);
			XMLHighScoreREAD.text = ScoreList[HighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = ScoreList[HighScoreIndex].date;
			XMLHighPlayerNameREAD.text = ScoreList[HighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = ScoreList[HighScoreIndex].time;
						if (XMLmanagerHighScore2ON){    
				List<ScoreEntry> ScoreList2 = new List<ScoreEntry>();
				ScoreList2 = PlayerPrefList();
				HighScore2Index = FindMaxScore2(ScoreList2);
	XMLHighScore2READ.text = ScoreList2[HighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = ScoreList2[HighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = ScoreList2[HighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = ScoreList2[HighScore2Index].time;	
			}
		}		
if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
						if(	PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_mode")=="FUN")
			{
				List<ScoreEntry> ScoreList3 = new List<ScoreEntry>();
				ScoreList3 = PlayerPrefList();
			FunHighScoreIndex = FindMaxFUNScore(ScoreList3);
			XMLHighScoreREAD.text = ScoreList3[FunHighScoreIndex].score.ToString("000") ;
			XMLHighDateREAD.text = ScoreList3[FunHighScoreIndex].date;
			XMLHighPlayerNameREAD.text = ScoreList3[FunHighScoreIndex].PlayerName;
	        XMLHighPlayerTimeREAD.text = ScoreList3[FunHighScoreIndex].time;
			if (XMLmanagerHighScore2ON){  
				List<ScoreEntry> ScoreList4 = new List<ScoreEntry>();
				ScoreList4 = PlayerPrefList(); 
				FunHighScore2Index = FindFUNMaxScore2(ScoreList4 );
				XMLHighScore2READ.text = ScoreList4[FunHighScore2Index].score.ToString("000") ;
				XMLHigh2DateREAD.text = ScoreList4[FunHighScore2Index].date;
				XMLHigh2PlayerNameREAD.text = ScoreList4[FunHighScore2Index].PlayerName;
				XMLHigh2PlayerTimeREAD.text = ScoreList4[FunHighScore2Index].time;
			}
			}
		}
		}
		}
		if (XMLmanagerLoadModeON) {
		if(Application.platform!=RuntimePlatform.WebGLPlayer && CheckSaveDirExist()){
			if(CheckSaveExist()){
				if(GameScoreDB.Score!=null){
					if(GameScoreDB.Score.Count!=0){
			LastScoreIndex = GameScoreDB.Score.Count - 1;}
			if(	GameScoreDB.Score[LastScoreIndex].mode=="FUN"){
				xTimer.XtimerFunMode();
			}
			else{
				xTimer.XtimerSpeedMode();
			}}}
		else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
if(	PlayerPrefs.GetString(PlPref_SvName+CountScoreData+"_mode")=="FUN"){
				xTimer.XtimerFunMode();
			}
			else{
				xTimer.XtimerSpeedMode();
			}
}
}else if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
			int CountScoreData = 0;
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
	if(	PlayerPrefs.GetString(PlPref_SvName+CountScoreData+"_mode")=="FUN"){
				xTimer.XtimerFunMode();
			}
			else{
				xTimer.XtimerSpeedMode();
			}
}
else{
				xTimer.XtimerSpeedMode();
}
		}
	}
	public void XMLWriteSSScore (){
		//List<ScoreEntry>	list1 = new List<ScoreEntry>();
		//ScoreEntry	score1  = new ScoreEntry (); //for everyTime NEW 
		if (XMLWriteSSScoreON) {
			if (XMLwriteToSameIndexON) {
			//write once to first index
			GameScoreDB.Score [0].score = XMLScoreWriter.GetComponent<XScore> ().XScoreFull;
			}
			else if(XMLwriteToLastIndexON){	
				if(GameScoreDB.Score.Count != 0){
				LastScoreIndex = GameScoreDB.Score.Count - 1;
GameScoreDB.Score [LastScoreIndex].score = XMLScoreWriter.GetComponent<XScore> ().XScoreFull;
				}}
			else {
				  //for everyTime NEW 
			ScoreEntry	score  = new ScoreEntry ();
			score.score = XMLScoreWriter.GetComponent<XScore> ().XScoreFull;
			GameScoreDB.Score.Add (score);
			}
		}
	}
	public void XMLWriteDate(){
		if (XMLWriteWriteDateON) {
		if (XMLwriteToSameIndexON) {
				GameScoreDB.Score [0].date = System.DateTime.Now.ToString ("dd.MM.yyyy");
		}
		if (XMLwriteToLastIndexON) {
				if(GameScoreDB.Score.Count != 0){
					LastScoreIndex = GameScoreDB.Score.Count - 1;
					GameScoreDB.Score [LastScoreIndex].date = System.DateTime.Now.ToString ("dd.MM.yyyy");
				}
			}
		}
	}
	public void XMLWriteMode(){
		if (XMLWriteWriteModeON) {
if(CheckSaveDirExist()){
		if (XMLwriteToSameIndexON) {
			if(modeSwitch!=null){
				GameScoreDB.Score [0].mode = modeSwitch.SetModeOn.ToString();}
		else if(GameScoreDB.Score.Count>=1){
				LastScoreIndex = GameScoreDB.Score.Count - 1;
				GameScoreDB.Score [0].mode = GameScoreDB.Score [LastScoreIndex-1].mode;					
			}
			else{
						GameScoreDB.Score [LastScoreIndex].mode = "SPEED";
			}
		}
		if (XMLwriteToLastIndexON) {	
			if(modeSwitch!=null){
				LastScoreIndex = GameScoreDB.Score.Count - 1;
				GameScoreDB.Score [LastScoreIndex].mode = modeSwitch.SetModeOn.ToString();
				}
				else if(GameScoreDB.Score.Count != 0){	
					if(GameScoreDB.Score.Count>=2 && GameScoreDB.Score[GameScoreDB.Score.Count - 2].mode!=""){
					LastScoreIndex = GameScoreDB.Score.Count - 1;
					GameScoreDB.Score [LastScoreIndex].mode = GameScoreDB.Score [LastScoreIndex-1].mode;
					}
					else{
						GameScoreDB.Score [LastScoreIndex].mode = "SPEED";
}
				}				
else{
					LastScoreIndex = GameScoreDB.Score.Count - 1;
						GameScoreDB.Score [LastScoreIndex].mode = "SPEED";
}			
			}
		}else{
			PlPrefWriteMode();
		}
		}
	}
	public void XMLWriteTime(){
		if (XMLWriteWriteTimeON) {
				if (XMLwriteToSameIndexON) {
				GameScoreDB.Score [0].time = xTimer.XtimerSaveTime().ToString ("00:00:00");
		}
		if (XMLwriteToLastIndexON) {
				if(GameScoreDB.Score.Count != 0){
					LastScoreIndex = GameScoreDB.Score.Count - 1;
				GameScoreDB.Score [LastScoreIndex].time = xTimer.XtimerSaveTime().ToString ("00:00:00");
				}
			}
		}
	}
	public void XMLWritePname (){
		if (XMLWriteWritePnameeON) {
			if (XMLwriteToSameIndexON) {
				if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
						GameScoreDB.Score [0].PlayerName = XMLPlayerNameDefault.text;
					}
					else{
					GameScoreDB.Score [0].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
					}}
				else{
				//write once to first index
				GameScoreDB.Score [0].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
				}}
			else if(XMLwriteToLastIndexON){	if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
						if(GameScoreDB.Score.Count != 0){
							LastScoreIndex = GameScoreDB.Score.Count - 1;
						GameScoreDB.Score [LastScoreIndex].PlayerName = XMLPlayerNameDefault.text;
						}else{
						GameScoreDB.Score [0].PlayerName = XMLPlayerNameDefault.text;	
						}}					
					else {					
						if(GameScoreDB.Score.Count != 0){
							LastScoreIndex = GameScoreDB.Score.Count - 1;
						GameScoreDB.Score [LastScoreIndex].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
						}else{
						GameScoreDB.Score [0].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();	
						}
						}}
					else{					
					if(GameScoreDB.Score.Count != 0){
						LastScoreIndex = GameScoreDB.Score.Count - 1;
				GameScoreDB.Score [LastScoreIndex].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
					}else{
						GameScoreDB.Score [0].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();	
						}
					}}
			else {
				ScoreEntry score = new ScoreEntry ();
				if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
						score.PlayerName = XMLPlayerNameDefault.text;
						GameScoreDB.Score.Add (score);
					}
					else{
				score.PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
				GameScoreDB.Score.Add (score);}}
				else{
					//for every time new
				score.PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ();
				GameScoreDB.Score.Add (score);
}}
		}
	}
	public int FindMaxScore(List<ScoreEntry> list)
	{
		//list<T>, delegate(GameScoreDB.Score x){ out MaXscore, out MaXscoreIndex}
		MaXscore = int.MinValue;
		MaXscoreIndex = int.MinValue;
		if (list.Count == 0) {
			//throw new InvalidDataException("Empty List");
		}
		if (list.Count != 0) {
			int listEntCount = 0;
			foreach (ScoreEntry listEnt in list)
			{
				listEntCount += 1;
				if (listEnt.score >= MaXscore && listEnt.mode=="SPEED")
				{
					MaXscore = (int)listEnt.score;
					MaXscoreIndex = listEntCount - 1;
				}

			}
			return MaXscoreIndex;
		}
		return MaXscoreIndex;
	}
	
	public int FindMaxMAX(List<ScoreEntry> list)
	{
		if (list.Count != 0) {
			int listEntCount2 = 0;
			MaXmaxScore = 0;
			foreach (ScoreEntry listEnt in list)
			{
				if (listEnt.score > MaXmaxScore && listEnt.mode=="SPEED"){	
					MaXmaxScore = (int)listEnt.score;
				}
			}
			
			return MaXmaxScore;
		}
		
		return MaXmaxScore;
	}
	public int FindMaxScore2(List<ScoreEntry> list)
	{
		MaXscore2 = 0;
		MaXscore2Index = 0;
		if (list.Count == 0) {
			//throw new InvalidDataException("Empty List");
		}
		if (list.Count != 0) {
			int listEntCount2 = 0;
			foreach (ScoreEntry listEnt in list)
			{
				listEntCount2 += 1;
				if (listEnt.score <= MaXscore && listEnt.mode=="SPEED"){
					if (listEnt.score < MaXscore && listEnt.score > MaXscore2){	
					MaXscore2 = (int)listEnt.score;
MaXscore2Index = listEntCount2 - 1;
}
					else if(listEnt.score == MaXscore && listEnt.score > MaXscore2 && (listEntCount2 - 1)!=FindMaxScore(list)){
					MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;
						}
						
								else if(listEnt.score == MaXscore && listEnt.score == MaXscore2 && (listEntCount2 - 1)!=FindMaxScore(list)){
					MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;						
			}
						else if(listEnt.score == MaXscore && list.Count<3){
								MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;
					}
				}
				}
			return MaXscore2Index;
		}
		return MaXscore2Index;
	}
	public int FindMaxFUNScore(List<ScoreEntry> list)
	{
		MaXscore = int.MinValue;
		MaXscoreIndex = int.MinValue;
		if (list.Count == 0) {
			//throw new InvalidDataException("Empty List");
		}
		if (list.Count != 0) {
			int listEntCount = 0;
			foreach (ScoreEntry listEnt in list)
			{
				listEntCount += 1;
				if (listEnt.score > MaXscore && listEnt.mode=="FUN")
				{
					MaXscore = (int)listEnt.score;
					MaXscoreIndex = listEntCount - 1;
				}

			}
			return MaXscoreIndex;
		}
		return MaXscoreIndex;
	}
	public int FindFUNMaxMAX(List<ScoreEntry> list)
	{
		if (list.Count != 0) {
			int listEntCount2 = 0;
			MaXmaxScore = 0;
			foreach (ScoreEntry listEnt in list)
			{
				if (listEnt.score > MaXmaxScore && listEnt.mode=="FUN"){	
					MaXmaxScore = (int)listEnt.score;
				}
			}
			return MaXmaxScore;
		}
		return MaXmaxScore;
	}
	public int FindFUNMaxScore2(List<ScoreEntry> list)
	{
		MaXscore2 = int.MinValue;
		MaXscore2Index = int.MinValue;
		if (list.Count == 0) {
			//throw new InvalidDataException("Empty List");
		}
		if (list.Count != 0) {
			int listEntCount2 = 0;
			foreach (ScoreEntry listEnt in list)
			{
				listEntCount2 += 1;
				if (listEnt.score <= MaXscore && listEnt.mode=="FUN"){
					if (listEnt.score < MaXscore && listEnt.score > MaXscore2){	
					MaXscore2 = (int)listEnt.score;
MaXscore2Index = listEntCount2 - 1;
					}
					else if(listEnt.score == MaXscore && listEnt.score > MaXscore2 && (listEntCount2 - 1)!=FindMaxFUNScore(list)){
					MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;
			}
								else if(listEnt.score == MaXscore && listEnt.score == MaXscore2 && (listEntCount2 - 1)!=FindMaxFUNScore(list)){
					MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;
			}
						else if(listEnt.score == MaXscore && list.Count<3){
								MaXscore2 = (int)listEnt.score;
						MaXscore2Index = listEntCount2 - 1;
					}
				}				
			}
			return MaXscore2Index;
		}
		return MaXscore2Index;
	}
private List<ScoreEntry> PlayerPrefList()
{	
List<ScoreEntry> PlPrefScoreList = new List<ScoreEntry>();
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
			if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
for(int i=0; i<=CountScoreData;i++){
	ScoreEntry PlPrefScoreEntry = new ScoreEntry();
	if(PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_name")!=null){
	PlPrefScoreEntry.PlayerName = PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_name");}
	else{PlPrefScoreEntry.PlayerName = "";}
	if(PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_date")!=null){
	PlPrefScoreEntry.date = PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_date");
	}else{
	PlPrefScoreEntry.date = "";	
	}
	PlPrefScoreEntry.score = (float)(PlayerPrefs.GetInt(PlPref_SvName+i.ToString()+"_score"));	
	if(PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_time")!=null){
	PlPrefScoreEntry.time = PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_time");
	}else{PlPrefScoreEntry.time = "";}
	if(PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_mode")!=null){	PlPrefScoreEntry.mode = PlayerPrefs.GetString(PlPref_SvName+i.ToString()+"_mode");
}else{	PlPrefScoreEntry.mode = "";
}
PlPrefScoreList.Add(PlPrefScoreEntry);
}
return PlPrefScoreList;
}
else{
return PlPrefScoreList;
}
}
void PlayerPrefSaveNext()
{	
			int CountScoreData = 0;
			if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
CountScoreData +=1;
			}
			PlayerPrefs.SetInt (PlPref_SvName+CountScoreData.ToString(), 1);
			PlPrefWriteDate();
			PlPrefWriteSSScore();
			PlPrefWriteMode();
			PlPrefWritePname();
			PlPrefWriteTime();
			 PlayerPrefs.Save ();
}
void PlayerPrefSave()
{	
		if(CheckSaveExist()){
		}
		else{
			if(PlayerPrefs.GetString(PlPref_SvName+CountScoreData.ToString()+"_time")!=null){
		PlayerPrefs.SetInt (PlPref_SvName+CountScoreData.ToString(), 1);
			}
			PlPrefWritePname();
			PlPrefWriteDate();
			PlPrefWriteSSScore();
			PlPrefWriteMode();
			PlPrefWriteTime();
			 PlayerPrefs.Save ();
}
}
	public void PlPrefWriteSSScore (){
		if (XMLWriteSSScoreON) {
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
			if (XMLwriteToSameIndexON) {
			//write once to first index
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
CountScoreData = 0;
			PlayerPrefs.SetInt (PlPref_SvName+CountScoreData.ToString()+"_score", Convert.ToInt32(XMLScoreWriter.GetComponent<XScore> ().XScoreFull));
			}
			else if(XMLwriteToLastIndexON){	
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
				
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
			PlayerPrefs.SetInt (PlPref_SvName+CountScoreData.ToString()+"_score", Convert.ToInt32(XMLScoreWriter.GetComponent<XScore> ().XScoreFull));
		} else {
				  //for everyTime NEW 	
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
				
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
CountScoreData +=1;
			PlayerPrefs.SetInt (PlPref_SvName+CountScoreData.ToString()+"_score", Convert.ToInt32(XMLScoreWriter.GetComponent<XScore> ().XScoreFull));
			}
		}
	}
	public void PlPrefWriteDate(){
		if (XMLWriteWriteDateON) {
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
		if (XMLwriteToSameIndexON) {
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
CountScoreData = 0;
			PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_date", System.DateTime.Now.ToString ("dd.MM.yyyy"));
		}
		if (XMLwriteToLastIndexON) {
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
			PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_date", System.DateTime.Now.ToString ("dd.MM.yyyy"));
							}
		}
	}
	public void PlPrefWriteMode(){
		if (XMLWriteWriteModeON) {
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
				if (XMLwriteToSameIndexON) {
			if(modeSwitch!=null){
			PlayerPrefs.SetString (PlPref_SvName+"0"+"_mode", modeSwitch.SetModeOn.ToString());
			}
		else if(CountScoreData>0){
				PlayerPrefs.SetString (PlPref_SvName+(CountScoreData-1).ToString()+"_mode", modeSwitch.SetModeOn.ToString());
			}
			else{	PlayerPrefs.SetString (PlPref_SvName+(CountScoreData).ToString()+"_mode", "SPEED");
			}
		}
		if (XMLwriteToLastIndexON) {
				if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
			if(modeSwitch!=null){
				PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_mode", modeSwitch.SetModeOn.ToString());
				}
				else if(CountScoreData != 0){
					if(CountScoreData>=1 &&PlayerPrefs.GetString(PlPref_SvName+(CountScoreData-1).ToString()+"_mode")!=""){
					PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_mode", PlayerPrefs.GetString(PlPref_SvName+(CountScoreData-1).ToString()+"_mode"));
					}
					else{
							PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_mode", "SPEED");
					}
				}
else{			
	PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_mode", "SPEED");
}
			}
		}
	}
	public void PlPrefWritePname (){
		if (XMLWriteWritePnameeON) {
	string PlPref_SvName = "WolverineHUG_ScoreData";
	int CountScoreData = 0;
	if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
			if (XMLwriteToSameIndexON) {
				if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
			PlayerPrefs.SetString (PlPref_SvName+"0"+"_name", XMLPlayerNameDefault.text);
				}
					else{
			PlayerPrefs.SetString (PlPref_SvName+"0"+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
					}}
				else{
				//write once to first index
			PlayerPrefs.SetString (PlPref_SvName+"0"+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
				}}
			else if(XMLwriteToLastIndexON){	
				if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
						if(CountScoreData != 0){
			PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameDefault.text);
						}
						else{
						PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameDefault.text);	
						}
						}					
					else {				
						if(CountScoreData != 0){
PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
						}
						else{
PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
						}}}
					else{					
					if(CountScoreData != 0){
PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
					}
					else{
					PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());	
					}}}
			else {
				CountScoreData +=1;
				if (XMLPlayerNameDefaultON) {
					if(XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString () == "")
					{
						PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameDefault.text);
					}
					else{				
						PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
					}}
				else{
					//for every time new
							PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_name", XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerChosenName.ToString ());
}}
		}
		
	}
	public void PlPrefWriteTime(){
		if (XMLWriteWriteTimeON) {
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
		if (XMLwriteToSameIndexON) {
			if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}
CountScoreData = 0;
			PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_time", xTimer.XtimerSaveTime().ToString ("00:00:00"));
		}
		if (XMLwriteToLastIndexON) {
			CountScoreData = 0;
			if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}}  
			PlayerPrefs.SetString (PlPref_SvName+CountScoreData.ToString()+"_time", xTimer.XtimerSaveTime().ToString ("00:00:00"));
				}
			}
		}
public void PlayerPrefLoad(){
		if(CheckSaveExist()){
		}
		else{
			int CountScoreData = 0;
	string PlPref_SvName = "WolverineHUG_ScoreData";
		if(PlayerPrefs.GetInt (PlPref_SvName+"0")==1){
while (PlayerPrefs.GetInt(PlPref_SvName+(CountScoreData+1).ToString())==1){
CountScoreData +=1;
}
			}
   // PlPref_mode = PlayerPrefs.GetInt (PlPref_SvName+CountScoreData.ToString()+"_mode")==1?true:false;
   // PlPref_score = PlayerPrefs.GetInt (PlPref_SvName+CountScoreData.ToString()+"_score");
   // PlPref_time = PlayerPrefs.GetInt (PlPref_SvName+CountScoreData.ToString()+"_time");
   // PlPref_date = PlayerPrefs.GetInt (PlPref_SvName+CountScoreData.ToString()+"_date");
   // PlPref_name = PlayerPrefs.GetInt (PlPref_SvName+CountScoreData.ToString()+"_name");
         
}}
}
[System.Serializable]
public class ScoreEntry {
	public string PlayerName;
	public string date;
	public string mode;
	public string time;
	public float score;
}

[System.Serializable]
public class GameScoreDatabase{
	[XmlArray("PlayerScore")]
	public List<ScoreEntry>	Score = new List<ScoreEntry>();
}
