using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XHitObj : MonoBehaviour {
	public int XHitDmgMOC = 5;
	public GameObject XHitTarget;
	public GameObject XHitMaker;
	public Collider XHitObjTargetCol;
	public Collider XHitObjHitMaker;
	void Start () {
		XHitObjTargetCol = XHitTarget.GetComponent<Collider>();
		XHitObjHitMaker = XHitMaker.GetComponent<Collider>();
	}
	void OnTriggerEnter(Collider XHitTarget)
	//void OnCollisionEnter(XHitObj XHitMaker)
	{
		if (Input.GetButtonDown ("Hug")) {
			//Random damage
			//XHitDmgMOC = Mathf.CeilToInt((Random.Range (10f, 20f)));
			if (XHitTarget == gameObject) {
				XHitTarget.GetComponent<XHealth> ().TakeXDmg (XHitDmgMOC);
			}
		}
	}
}