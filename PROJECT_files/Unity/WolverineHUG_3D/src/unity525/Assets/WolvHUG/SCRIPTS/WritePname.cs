using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class WritePname : MonoBehaviour {
	public GameScoreDatabase GameScoreDB;
	public GameObject PlayerNameWriter;
	public void WritePlayerName(){
		PlayerNameWriter.GetComponent<XPlayers> ().XPlayerNameSet ();
		ScoreEntry score1 = new ScoreEntry ();
		score1.PlayerName = PlayerNameWriter.GetComponent<XPlayers>().XPlayerChosenName.ToString();
	}
}
