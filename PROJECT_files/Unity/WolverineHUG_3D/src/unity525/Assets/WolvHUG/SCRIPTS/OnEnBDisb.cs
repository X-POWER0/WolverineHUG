using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class OnEnBDisb : MonoBehaviour {
	public UnityEvent OnElementEnable;
    	public UnityEvent OnElementDisable;
	void OnEnable(){
    OnActiveSwitch();
	}

    public void OnDisableSwitch(){     
//    Debug.Log("OnActiveElement OnDisable");
		OnElementDisable.Invoke();		
    }
    public void OnActiveSwitch(){
		OnElementEnable.Invoke();	
      //  this.transform.parent.gameObject.SetActive(false);
        }
}
