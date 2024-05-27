using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class OpacWolv : MonoBehaviour{
[SerializeField] private Material WolvBaseMat;
[SerializeField] private Material WolvOpacMat;
[SerializeField] private Material WolvSlowMat;
[SerializeField] private Material WolvFastMat;
[SerializeField] private Texture WolvBaseTex;
[SerializeField] private Texture WolvOpacTex;
[SerializeField] private Texture WolvSlowTex;
[SerializeField] private Texture WolvFastTex;
[SerializeField] private Material[] WolvMatsBase;
[SerializeField] private Material[] WolvMatsChange;
[SerializeField] private SkinnedMeshRenderer WolvModel;
[SerializeField] private XScore WolvScore;
[SerializeField] private float WolvScoreLast;
[SerializeField] private int KillsRate=4;

[SerializeField] private float TimeRate=20f;
[SerializeField] private bool _opacMat=false;
		
public bool OpacMat{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return _opacMat;}
    set { _opacMat = value;}

}
private float TimeCounter=0f;
	void Start () {
WolvMatsBase = new Material[WolvModel.sharedMaterials.Length];
WolvMatsBase = WolvModel.sharedMaterials;
WolvOpacMat = WolvSlowMat;
WolvMatsChange = new Material[WolvModel.sharedMaterials.Length];
WolvMatsChange=WolvModel.sharedMaterials;
WolvMatsChange[5]=WolvOpacMat;
	}
	public void SetOpac(){
				WolvModel.materials=WolvMatsChange;
		_opacMat=true;
		}
	public void ActivateSlowMat(){
		WolvOpacMat = WolvSlowMat;
WolvMatsChange[5]=WolvOpacMat;
		WolvModel.materials=WolvMatsChange;
}
	public void ActivateFastMat(){	
		WolvOpacMat = WolvFastMat;
WolvMatsChange[5]=WolvOpacMat;
		WolvModel.materials=WolvMatsChange;
	}
	
	public void DisOpac(){
		if(_opacMat){
		_opacMat=false;
		WolvModel.materials=WolvMatsBase;
		}}
	void Update () {
if(_opacMat){
if(Time.time>TimeCounter){
	TimeCounter=Time.time+TimeRate;
	WolvScoreLast=WolvScore.XScoreKill;
}
else if(TimeCounter>Time.time && WolvScore.XScoreKill>WolvScoreLast+KillsRate){
ActivateFastMat();
}
else{
	ActivateSlowMat();
}
}
	}
	
}
