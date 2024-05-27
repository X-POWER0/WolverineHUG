using UnityEngine;
using System.Collections;
public class PlayerRespawn : MonoBehaviour {
[SerializeField]  float minX;
[SerializeField]  float maxX;
[SerializeField]  float minY;
[SerializeField]  float maxY;
[SerializeField]  float minZ;
[SerializeField]  float maxZ;
Vector3 StartPos;
	// Use this for initialization
	void Start () {
	StartPos=this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
if(this.transform.position.x<minX || this.transform.position.x>maxX || this.transform.position.y<minY || this.transform.position.y>maxY || this.transform.position.z<minZ || this.transform.position.z>maxZ){
		this.transform.position = StartPos;
	}
	}
}
