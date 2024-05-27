using UnityEngine;
using System.Collections;

public class XHitPlace : MonoBehaviour {
	public GameObject XHitHolder;
	public Vector3 XHitHolderPos;
	public GameObject XHitTarget;
	public float XHitY;
	public float XHitZ;
	public string XHitHolderTAG;
	public string XHitObjTAG;
	public string XHitTargetTAG;
	public int XHitHolderLAYER;
	public int XHitObjLAYER;
	public int XHitTargetLAYER;
	public Collider XHitObjCollider;
	public Collider XHitHolderCollider;
	public Collider XHitTargetCollider;
	public Collider XHitHolderCollCap;
	public GameObject XHitObjModel;
		public Color FxTestColor;
	void Start () {
		XHitHolder.gameObject.GetComponent<Collider>().gameObject.tag = XHitHolderTAG;
		this.gameObject.GetComponent<Collider>().gameObject.tag = XHitObjTAG;
		XHitTarget.gameObject.GetComponent<Collider>().gameObject.tag = XHitTargetTAG;
		XHitHolder.gameObject.GetComponent<Collider>().gameObject.layer = XHitHolderLAYER;
		this.gameObject.GetComponent<Collider>().gameObject.layer = XHitObjLAYER;
		XHitTarget.gameObject.GetComponent<Collider>().gameObject.layer = XHitTargetLAYER;
		XHitObjCollider = this.gameObject.GetComponent<Collider>();
		XHitHolderCollider = XHitHolder.GetComponent<Collider>();
		XHitHolderCollCap = XHitHolder.GetComponent<CapsuleCollider>();
		XHitTargetCollider = XHitTarget.GetComponent<Collider>();
		if (this.tag == "WolvHit") {
			XHitObjModel.gameObject.GetComponent<Renderer>().material.color = FxTestColor;
		}
		Physics.IgnoreCollision (XHitHolderCollider, XHitObjCollider, true); 
		Physics.IgnoreCollision (XHitHolderCollCap, XHitObjCollider, true); 
		Physics.IgnoreCollision (XHitTargetCollider, XHitObjCollider, false);
	}
	void Update () {
		XHitHolderPos = XHitHolder.gameObject.GetComponent<Transform>().transform.position;
		XHitHolderPos.y = XHitHolderPos.y + XHitY;
		XHitHolderPos.z = XHitHolderPos.z + XHitZ;
		this.gameObject.GetComponent<Transform>().transform.position = XHitHolderPos;
	}
	void OnTriggerEnter(Collider ObjOther){
		Physics.IgnoreCollision (XHitObjCollider, ObjOther, true);
	}
}