using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class XonEnabled : MonoBehaviour {
	public GameObject XonEnableObj;
	public bool XonEnableON = true;
	public bool XonEnableObjIsActive;
	public bool XonEnableObjIsActiveWorkON = true;
	public UnityEvent XonEnableAction;
	void Start () {
		XonEnableObjIsActive = XonEnableObj.gameObject.activeInHierarchy;
	}
	
	void Update () {
		XonEnableObjIsActive = XonEnableObj.gameObject.activeInHierarchy;
		if (XonEnableON) {
			if (XonEnableObjIsActive && XonEnableObjIsActiveWorkON){
				XonEnableAction.Invoke ();
				XonEnableObjIsActiveWorkON = false;
			}
			if (!XonEnableObjIsActive && !XonEnableObjIsActiveWorkON){
					XonEnableAction.Invoke ();
					XonEnableObjIsActiveWorkON = true;
				}
			}
		}
	}

/*
public class XonEnableAction : MonoBehaviour, ISelectHandler {
	public UnityEvent Selected;
	[SerializeField]
	public XonEnableAction context;
	public void onSelect(BaseEventData eventData){
		
		Debug.Log (this.gameObject.name + " was selected");
		Selected.Invoke(this);		
		UnityEvent<XonEnableAction>  Selected;
	}}
	*/