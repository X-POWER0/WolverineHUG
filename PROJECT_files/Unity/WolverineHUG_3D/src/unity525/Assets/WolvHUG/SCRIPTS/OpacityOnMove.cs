using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpacityOnMove : MonoBehaviour {
	public SkinnedMeshRenderer MeshObj;
	public Material Mat0;
	public Material Mat1;
	public Material Mat2;
	public Material Mat3;
	public Material Mat4;
	public Material Mat5;
	public Material BasicMat0;
	public Material BasicMat1;
	public Material BasicMat2;
	public Material BasicMat3;
	public Material BasicMat4;
	public Material BasicMat5;

	float Xmove;
	float Ymove;
	bool ChangedColor = false;
	public List<Material> MainMats = new List<Material> ();
	public List<Color> StartedColors = new List<Color>();
	public List<Material>	ChangeToMat = new List<Material>();
	
	public List<Material>	BasicMat = new List<Material>();
	void Start () {
		ChangeToMat.Add(Mat0);
		ChangeToMat.Add(Mat1);
		ChangeToMat.Add(Mat2);
		ChangeToMat.Add(Mat3);
		ChangeToMat.Add(Mat4);
		ChangeToMat.Add(Mat5);
		foreach(Material mat in MeshObj.materials){
			MainMats.Add (mat);
		}
		BasicMat0 = MainMats[0];
		BasicMat1 = MainMats[1];
		BasicMat2 = MainMats[2];
		BasicMat3 = MainMats[3];
		BasicMat4 = MainMats[4];
		BasicMat5 = MainMats[5];
		BasicMat.Add(BasicMat0);
		BasicMat.Add(BasicMat1);
		BasicMat.Add(BasicMat2);
		BasicMat.Add(BasicMat3);
		BasicMat.Add(BasicMat4);
		BasicMat.Add(BasicMat5);
		for(int i=0 ; i<= MainMats.Count-1; i++ ){
			MeshObj.materials[i] = MainMats[i]; 
		}
	}
	void Update () {
		Xmove = Input.GetAxis("Horizontal");
		Ymove = Input.GetAxis("Vertical");
		if(Xmove>0||Xmove<0||Ymove>0||Ymove<0){
			ColorChange();
		}
		else
		{
			ColorChangeBack();
		}
	}
	void ColorChange(){
		if(!ChangedColor){
			for(int i=0 ; i<= MainMats.Count-1; i++ ){
				MainMats[i] = ChangeToMat[i];
				MeshObj.materials[i] = MainMats[i];
			}
			ChangedColor = true;
		}
	}
	void ColorChangeBack(){
		if(ChangedColor){
			for(int i=0 ; i<= MainMats.Count-1; i++ ){
				MainMats[i] = BasicMat[i];
				MeshObj.materials[i] = MainMats[i];
			}
			ChangedColor = false;
		}
	}
}