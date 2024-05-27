using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XMeleeSys : MonoBehaviour {
public GameObject XMSsender;
public int XMSDmg = 50;
public float XMSDistance;
public float XMSDistanceMax = 1.5f;
	private RaycastHit hit;
	public Transform TheSystem;
	void Update () {
//if (CrossPlatformInputManager.GetButtonDown("HUG"))
if (Input.GetButton("Hug"))
{
AttackDammage ();
			if (Physics.Raycast( transform.position, transform.TransformDirection(Vector3.forward), out hit))
			{
				XMSDistance = hit.distance;
				if (XMSDistance < XMSDistanceMax)
				{
					hit.transform.SendMessage("ApplyDammage", XMSDmg, SendMessageOptions.DontRequireReceiver);
				}
			}
}
}
	void AttackDammage (){
	}	
}