using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class WriteScore : MonoBehaviour {
	public GameScoreDatabase GameScoreDB;
	public GameObject ScoreWriter;
	public void getScore(){
	ScoreEntry score1 = new ScoreEntry ();
		score1.score = ScoreWriter.GetComponent<XScore> ().XScoreFull;
	
	}
	void Update () {		
		ScoreEntry score1 = new ScoreEntry ();
		score1.score = ScoreWriter.GetComponent<XScore> ().XScoreFull;
	}
}
