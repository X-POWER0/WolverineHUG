using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Xscroll : MonoBehaviour {

public GameObject XscrollTarg;
	public Scrollbar XscrollScrollbr;
	float XscrollTargPos;
	float XscrollScrollbrVal;
	public void onValueChanged(float value)
	{
		XscrollTargPos = XscrollTarg.transform.position.y;
		XscrollScrollbrVal = XscrollScrollbr.value;
		XscrollTargPos = XscrollTargPos + XscrollScrollbrVal;
		var XscrollTargRlpY = XscrollTarg.GetComponent<RectTransform> ().localPosition.y;
}
	public void XscrollFupPosY(float textUpdateNumber)
	{var XscrollTargRlpY = XscrollTarg.GetComponent<RectTransform> ().localPosition.y;
		var RLpy = XscrollTargRlpY;
		if ((textUpdateNumber > 0.79) && (textUpdateNumber< 0.81)) {
			transform.localPosition = new Vector3(1f, 0.8f, 1f); 
}
else {
transform.localPosition = new Vector3(1f, textUpdateNumber,1f);
} 
	}

}
