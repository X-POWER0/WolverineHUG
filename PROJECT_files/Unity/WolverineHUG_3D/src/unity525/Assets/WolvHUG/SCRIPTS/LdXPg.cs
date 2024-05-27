using UnityEngine;
using System.Collections;

public class LdXPg : MonoBehaviour {
public int pgCount;
public int pgCounterStrt;
public int pgCounter;
public GameObject BtnNextX;
public GameObject BtnPartNextX;
public GameObject BtnPrevX;	
	public GameObject BtnPartPrevX;
	public GameObject pgTarget;
	public string pgName;
	public string pgLastTarget;
	public GameObject CountedPg;	
public void OnClick(){
		CountedPg = pgTarget;
		pgName = pgTarget.name;
		if (pgCounter < pgCounterStrt) {
			pgCounter = pgCounterStrt;
		}
		pgLastTarget = pgName + pgCount;
		if (pgCounter < pgCount) {
			pgCounter = pgCounter + 1;
			var pgCountName = pgName + pgCounter;
			CountedPg.name = pgCountName;
			var CountedPg1 = GameObject.Find(pgCountName);
	
			if (CountedPg1.activeInHierarchy == false) {
				CountedPg1.SetActive (true);
				BtnPrevX.SetActive (true);
				BtnPartPrevX.SetActive (true);
			}
		}
			if(pgCounter == pgCount){
			CountedPg.name = pgLastTarget;
			var CountedPg1 = GameObject.Find(pgLastTarget);
			if (CountedPg1.activeInHierarchy == false){
				CountedPg1.SetActive(true);
				BtnNextX.SetActive(false);
				BtnPartNextX.SetActive(false);
				}}
}
	}

