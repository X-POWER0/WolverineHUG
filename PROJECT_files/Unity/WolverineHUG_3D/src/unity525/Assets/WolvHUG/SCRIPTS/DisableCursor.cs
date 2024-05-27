using UnityEngine;
using System.Collections;

public class DisableCursor : MonoBehaviour {
		void Start () {
	
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {
	if(Cursor.visible){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
	}
	}

}
