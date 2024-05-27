using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class XMLmanagerONload : MonoBehaviour {
	public GameObject XMLScoreWriter;
	public GameObject XMLPlayerNameWriter;
	public static XMLmanagerONload ins;
	public bool XMLWriteSSScoreON = true;
[SerializeField] private ModeSwitch XMLPlayerModeWriter;
	void Awake (){
		ins = this;
	}
	public GameScoreDatabase GameScoreDB;
	public ScoreEntry score1 = new ScoreEntry ();
	public void SaveGameScore(){
		XMLWritePname ();
		XMLWriteSSScore ();
		XMLWriteMode();
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml", FileMode.OpenOrCreate);
		serializer.Serialize (stream, GameScoreDB);
		stream.Close ();
	}
	public void LoadGameScore(){
		XmlSerializer serializer = new XmlSerializer (typeof(GameScoreDatabase));
		if (File.Exists (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml")) {
			FileStream stream = new FileStream (Application.dataPath + "/SAVE_DATA/SCORE/score_data.xml", FileMode.Open);
			GameScoreDB = serializer.Deserialize (stream) as GameScoreDatabase;
			stream.Close ();
		} else {
			Debug.Log("No FILE");
		}
	}
	void Start () {
				LoadGameScore();
	}
	public void XMLWriteSSScore (){
		if (XMLWriteSSScoreON) {
			GameScoreDB.Score [0].score = XMLScoreWriter.GetComponent<XScore> ().XScoreFull;
		}

	}

	public void XMLWritePname (){
		XMLPlayerNameWriter.GetComponent<XPlayers> ().XPlayerNameSet ();
		GameScoreDB.Score[0].PlayerName = XMLPlayerNameWriter.GetComponent<XPlayers>().XPlayerChosenName.ToString();		
	}
	
		
	public void XMLWriteMode(){
		//List<ScoreEntry>	list1 = new List<ScoreEntry>();
		//ScoreEntry	score1  = new ScoreEntry (); //for everyTime NEW 
		GameScoreDB.Score [0].mode = XMLPlayerModeWriter.SetModeOn.ToString();
		//XMLScoreWriter.GetComponent<XScore> ().XScoreFull;
		//GameScoreDB.list.Insert ( 1, score1);
		
		
	}
}