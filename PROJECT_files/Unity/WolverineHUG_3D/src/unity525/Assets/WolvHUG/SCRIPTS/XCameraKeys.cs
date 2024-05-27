using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class XCameraKeys : MonoBehaviour {
	public GameObject CameraObjForXCamKeys;
public GameObject SetObjForXCamKeys{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return CameraObjForXCamKeys;}
    set { CameraObjForXCamKeys = value;}

}
	public GameObject CameraObjXCamController;
public GameObject SetCamController{
	get { return CameraObjXCamController;}
    set { CameraObjXCamController = value;}
}
	public bool XCamKeysON = true;
	public KeyCode XCamKeysKey;
	private KeyCode XCamRotateY;
	private float XCamRotationY;
	public float DisplayXCamRotationY;
	public string CamControllingScript;
	public string CamControllingScriptVar;
	public float XCamSpeed = 75.0f;
	public UnityStandardAssets.Cameras.FreeLookCam THPcam;
public UnityStandardAssets.Cameras.FreeLookCam SetTHPcam{
	get { return THPcam;}
    set { THPcam = value;}
}
[SerializeField] private bool WHtoFreeLook = false;
public bool SetWHtoFreeLook{
	get { return WHtoFreeLook;}
    set { WHtoFreeLook = value;}

}
	public UnityStandardAssets.Cameras.WHFreeLookCam THPcamWH;
public UnityStandardAssets.Cameras.WHFreeLookCam SetTHPcamWH{
	get { return THPcamWH;}
    set { THPcamWH = value;}
}
	void Start () {
		DisplayXCamRotationY = CameraObjXCamController.GetComponent<Transform> ().transform.localRotation.x;
		XCamRotationY = CameraObjXCamController.GetComponent<Transform> ().transform.localRotation.x;
	}
	void Update () {
		DisplayXCamRotationY = CameraObjXCamController.GetComponent<Transform> ().transform.localRotation.x;;
	Vector3 XCamV3 = new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f);
		if (Input.GetAxis("Horizontal") < 0) {
			CameraObjXCamController.transform.Rotate (XCamV3 * XCamSpeed * Time.deltaTime);
		}
		else if (Input.GetAxis("Horizontal") > 0) {
			CameraObjXCamController.transform.Rotate (XCamV3 * XCamSpeed * Time.deltaTime);
		}
		else{
		}

	}
}
