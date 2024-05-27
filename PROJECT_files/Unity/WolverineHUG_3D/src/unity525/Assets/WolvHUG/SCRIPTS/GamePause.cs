using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
	void Start () {
			Time.timeScale = 1;
	}
	public void PauseGameWH(){
			Time.timeScale = 0;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
	}
	
	public void UnPauseGameWH(){
			Time.timeScale = 1;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			
	}
}
