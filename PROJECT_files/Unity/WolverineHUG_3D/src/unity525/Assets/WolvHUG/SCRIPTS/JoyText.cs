using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class JoyText : MonoBehaviour {
[SerializeField]  ExitMenu MainMenu;
[SerializeField]  int _selectedMenuBtnNumber=-1;

public int SelectedMenuBtnNumber{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return _selectedMenuBtnNumber;}
    set { _selectedMenuBtnNumber = value;}

}
[SerializeField]  Button _invisibleBtn;
public Button SetinvisibleBtn{
 	get { return _invisibleBtn;}
    set { _invisibleBtn = value;}

}
[SerializeField]  private GameObject SelectedMenuBtnFX;
		private bool SelectIncreasKeyUp = true;	
		private bool SelectDecreasKeyUp = true;	
		private bool SubMenuMaxSubmitLvl = false;	
public bool SelectKeysDown(List<KeyCode> PressedKeys){
foreach (KeyCode pressedKey in PressedKeys){ 
if(Input.GetKeyDown(pressedKey)) {
	return true;
	}
}
return false;
}
public bool SelectKeysUp(KeyCode pressedKey){ 
if(Input.GetKeyUp(pressedKey)) return true;
return false;
}
[SerializeField ] private Button _selectedMenuButton=null;
public Button SelectedMenuButton {
	get { return _selectedMenuButton ;}
    set { _selectedMenuButton = value;}

}

		bool ExitKeyUp = true;
		bool SubmitKeyUp = true;
	[SerializeField ] private ControlPinputField controlPanel;
	[SerializeField ] private bool ControlPanelON = false;
public bool SetControlPanelON {
	get { return ControlPanelON;}
    set { ControlPanelON = value;}

}
KeyCode eLast=KeyCode.None;
Array allKeyCodes;
float TimePress;			
[SerializeField]  private int ExitKeyPhases=0;
[SerializeField]  private int ExitKeyPhasesMax;

[SerializeField] private List<Button> ExitMenuBtnList = new List<Button>();

[SerializeField] private List<Button> SubmitMenuBtnList = new List<Button>();
[SerializeField]  private int SubmitKeyPhases=0;
[SerializeField]  private int SubmitKeyPhasesMax;
[SerializeField] private List<Button> SelectebMenuBtnList = new List<Button>();
[System.Serializable] public class ButtonList
{
	public List<Button> list= new List<Button>();
} 

public List<ButtonList> SelectebleMenuBtnsLists = new List<ButtonList>();
[SerializeField] private bool _joyInputON=false;
public bool SetJoyInputON{
	get { return _joyInputON;}
    set { _joyInputON = value;}
}
[SerializeField] private InputField inputField;
	Color basePressedColor;	
Color baseNormColor;
[SerializeField] bool CapslockOn= false;
ColorBlock CapsColorBlock;
[SerializeField] Color capslockOnNormColor;
[SerializeField] Color capslockOnPressColor;
[SerializeField] GameObject InputTypePanel;
[SerializeField] GameObject DeactiveInputButton;
[SerializeField] GameObject ActiveInputButton;
[SerializeField] Button LeftCursorKeyButtn;
[SerializeField] Button RightCursorKeyButtn;
[SerializeField] Button BackSpaceKeyButtn;
[SerializeField] Button OkKeyButtn;
[SerializeField] Button CapslockInputButton;
string JoyCheckStr="";
int CaretPosSubId = 0;

    void Awake(){
allKeyCodes=System.Enum.GetValues(typeof(KeyCode));
CaretPosSubId = 0;
}
	void Start () {
		SubmitMenuBtnList[0].Select();
basePressedColor = CapslockInputButton.colors.pressedColor;
baseNormColor = CapslockInputButton.colors.normalColor;
CapsColorBlock=CapslockInputButton.colors;
			TimePress=Time.time;
SelectebleMenuBtnsLists [0].list=SelectebMenuBtnList;
	}
	void Update () {
if(_joyInputON){
	if (Input.GetButtonDown("Cancel") && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()||
	Input.GetButtonDown("Cancel") && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			ExitKeyUp = false;
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;

if(SelectedMenuBtnNumber<=-2){
_selectedMenuBtnNumber=0;
SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
_selectedMenuBtnNumber=-2;
SubMenuMaxSubmitLvl=true;
}else{
_selectedMenuBtnNumber=0;
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		SelectedBtnFx();
}
	}

	if (Input.GetButtonDown("Cancel")  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time && Time.timeScale!=0 || TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() ||
	Input.GetButtonDown("Cancel")  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() ){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			ExitKeyUp = false;
	}

if (SelectedMenuButton==ExitMenuBtnList[ExitKeyPhases]){
	if ( Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time && Time.timeScale!=0 || Time.timeScale!=0 && TimePress<Time.time && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()|| 
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke(); 
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;
_selectedMenuBtnNumber=0;
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
SelectedBtnFx();
	}

}

if (SelectedMenuButton==ExitMenuBtnList[ExitKeyPhases]){
	if (  Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time  && Time.timeScale!=0|| TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() || 
	 Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
	}

}

//Select buttons to type Start
	if(Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl||
	 Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || Time.timeScale==0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl){
			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(_selectedMenuBtnNumber<SelectebMenuBtnList.Count-1){
		_selectedMenuBtnNumber+=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
	if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
			}		
		SelectedBtnFx();
					_invisibleBtn.Select();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;}
		else if(_selectedMenuBtnNumber>=SelectebMenuBtnList.Count-1){
			_selectedMenuBtnNumber=0;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];}
		SelectedBtnFx();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
	}
	if( Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || 
	Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || Time.timeScale==0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl)
{			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(-_selectedMenuBtnNumber-2<(SelectebMenuBtnList.Count-1)){
		_selectedMenuBtnNumber-=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[-_selectedMenuBtnNumber-2].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-_selectedMenuBtnNumber-2];
		}
		SelectedBtnFx();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(-_selectedMenuBtnNumber-2>=(SelectebMenuBtnList.Count-1)){
			_selectedMenuBtnNumber=0;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		_selectedMenuBtnNumber=-2;
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}}
			if( Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl ||
			Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || Time.timeScale==0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl 
)
{			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(-_selectedMenuBtnNumber-2>0){
		_selectedMenuBtnNumber+=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
	
		if(SelectebMenuBtnList[-_selectedMenuBtnNumber-2].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-_selectedMenuBtnNumber-2];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(-_selectedMenuBtnNumber-2<=0){
		_selectedMenuBtnNumber=-(SelectebMenuBtnList.Count-1)-2;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			
		if(SelectebMenuBtnList[-(_selectedMenuBtnNumber+2)].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-(_selectedMenuBtnNumber+2)];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}}
	if(Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl
||
Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || Time.timeScale==0 && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl ){
			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(_selectedMenuBtnNumber>0){
	_selectedMenuBtnNumber-=1;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(_selectedMenuBtnNumber<=0){
		_selectedMenuBtnNumber=SelectebMenuBtnList.Count-1;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
	}
//Select buttons to type END

if (SelectedMenuButton==SubmitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()
	||
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()
	){
SubmitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			SubmitKeyUp = false;
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
if(_selectedMenuBtnNumber<=-2){
SelectedMenuButton=SubmitMenuBtnList[SubmitKeyPhasesMax];
_selectedMenuBtnNumber=-2;
SubMenuMaxSubmitLvl = false;
}else{
_selectedMenuBtnNumber=0;
SelectedMenuButton = SubmitMenuBtnList[ExitKeyPhases];
	}
SelectedBtnFx();
	}}


if (SelectedMenuButton==SubmitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()||
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()){
SubmitMenuBtnList[ExitKeyPhases].onClick.Invoke();
SelectedMenuButton=null;
			SubmitKeyUp = false;
_selectedMenuBtnNumber=-1;
SelectebMenuBtnList = SelectebleMenuBtnsLists[0].list;
	}
}
if (SelectedMenuButton!=null && _selectedMenuBtnNumber!=-1 && SelectedMenuButton!=SubmitMenuBtnList[ExitKeyPhases] && SelectedMenuButton!=ExitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp ||
	Input.GetButtonDown("Submit")  && SubmitKeyUp&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp){
if(SubmitKeyPhasesMax>ExitKeyPhasesMax && SubmitKeyPhases!=SubmitKeyPhasesMax){
SubmitKeyPhases=SubmitKeyPhasesMax;
SelectedMenuBtnNumber=-2;
SelectedMenuButton.onClick.Invoke();
SelectedMenuButton=SubmitMenuBtnList[SubmitKeyPhasesMax];
		SelectedBtnFx();
}
else{
SelectedMenuButton.onClick.Invoke();
SubMenuMaxSubmitLvl = false;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
//had out of range recheck
		SelectedBtnFx();
}
	}
}
}

//check if Joystic used for typing Player Name START
        if (Input.anyKey){
      KeyCode curKey= KeyCode.None;
foreach (KeyCode tempKey in allKeyCodes){
	if(Input.GetKeyDown(tempKey)){
		curKey=tempKey;
				if(tempKey.ToString().ToCharArray().Length>=4){
		JoyCheckStr=tempKey.ToString().Substring(0,3);
		if(JoyCheckStr.Contains("joy"))	{
if(!_joyInputON){
_joyInputON=true;
InputTypePanel.SetActive(true);
		SubmitMenuBtnList[0].Select();
}
		}
		}
		else{
_joyInputON=false;
InputTypePanel.SetActive(false);
		}	
	}
}
if(_joyInputON){
	    if (curKey!=eLast){
					ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp =true;
						SelectIncreasKeyUp = true;						
eLast=curKey;
			if(Time.timeScale!=0){
			TimePress = Time.time+1*Time.deltaTime;}
			if(Input.GetButtonDown("Cancel")){
		ExitKeyUp = false;
		SubmitKeyUp = true;
			SelectDecreasKeyUp = true;
						SelectIncreasKeyUp = true;
						}
			if(Input.GetButtonDown("Submit")){
		ExitKeyUp = true;
		SubmitKeyUp = false;
			SelectDecreasKeyUp = true;
						SelectIncreasKeyUp = true;
						}
			if(Input.GetAxisRaw("Horizontal")<0 || Input.GetAxisRaw("Vertical")<0){
		ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp = false;
						SelectIncreasKeyUp = true;		
						}	
			if(Input.GetAxisRaw("Horizontal")>0  || Input.GetAxisRaw("Vertical")>0 ){
		ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp =true;
						SelectIncreasKeyUp = false;	
						}
	}
		else{eLast=curKey;
			if(Time.timeScale==0){
			if(Input.GetButtonUp("Submit")){
				SubmitKeyUp = true;
			}
			if(Input.GetButtonUp("Cancel")){
				ExitKeyUp = true;
			}
			if(Input.GetAxisRaw("Vertical")==0 && Input.GetAxisRaw("Horizontal")==0 && Time.timeScale!=0){
				SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;
			}
		}
		}
		}
		else {
				if(TimePress<Time.time && Time.timeScale!=0){
eLast=KeyCode.None;
		}
			if(Time.timeScale==0){
eLast=KeyCode.None;
	SubmitKeyUp = true;
				ExitKeyUp = true;
		SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;	
	}
		}
			if(Input.GetButtonUp("Submit")){
				SubmitKeyUp = true;
			}
			if(Input.GetButtonUp("Cancel")){
				ExitKeyUp = true;
			}
			if(Input.GetAxisRaw("Vertical")==0 && Input.GetAxisRaw("Horizontal")==0 && Time.timeScale!=0){
				SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;
			}
// bind buttons for easier typing
			if(Input.GetButtonDown("Crouch")){		
RightCursorKeyButtn.onClick.Invoke();
	}
			if(Input.GetButtonDown("Camera")){
LeftCursorKeyButtn.onClick.Invoke();
			}
			if (Input.GetButton("Walk")){	
	CapslockInputButton.onClick.Invoke();
			}
			if(Input.GetButtonDown("Hug")){			
	BackSpaceKeyButtn.onClick.Invoke();
			}
		}
			if(Input.GetButtonDown("Jump")){				
OkKeyButtn.onClick.Invoke();
	}
	}
//check Joystic used for typing Player Name END


public void setSubmitKeyUp(bool bl){
SubmitKeyUp = bl;
}
public void SetSelectedMenuBtnNumber(int value){	
	SelectedMenuBtnNumber=value;
}
public void setSelectedMenuButton(Button btn){
	SelectedMenuButton=btn;
}
public void setSubMenuMaxSubmitLvl(bool bl){
	SubMenuMaxSubmitLvl=bl;
}
public void SelectedBtnFx(){
if(SelectedMenuBtnFX!=null){
	if(SelectedMenuButton.IsActive()){
	SelectedMenuBtnFX.SetActive(true);
SelectedMenuBtnFX.transform.position=SelectedMenuButton.transform.position;
SelectedMenuBtnFX.transform.localScale = new Vector2(SelectedMenuButton.transform.localScale.x,SelectedMenuBtnFX.transform.localScale.y);
	}
}
}

// Typing functions for onscreen buttons of JoyInput
public void TypeLetterButtonAct(Text txtKey){
	string typeKey;
	inputField.ActivateInputField();
	if(CapslockOn){
	typeKey = txtKey.text;
	typeKey = typeKey.ToUpper();
	}else{
	typeKey = txtKey.text;}
	int subId = CaretPosSubId;
	inputField.caretPosition=subId;
	string baseText = inputField.text;
	string bfrCaret = inputField.text.Substring(0,subId);
	string aftrCaret = inputField.text.Substring(subId);
	inputField.text = bfrCaret+typeKey+aftrCaret;
inputField.caretPosition=subId+1;
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void TypeSymbolButtonAct(Text txtKey){
	string typeKey = txtKey.text;
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
	subId = CaretPosSubId;
	inputField.caretPosition=subId;
	string baseText = inputField.text;
	string bfrCaret = inputField.text.Substring(0,subId);
	string aftrCaret = inputField.text.Substring(subId);
	inputField.text = bfrCaret+typeKey+aftrCaret;
inputField.caretPosition=subId+1;
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void TypeSpaceButtonAct(){
	string typeKey = " ";
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
	subId = CaretPosSubId;
	inputField.caretPosition=subId;
	string baseText = inputField.text;
	string bfrCaret = inputField.text.Substring(0,subId);
	string aftrCaret = inputField.text.Substring(subId);
	inputField.text = bfrCaret+typeKey+aftrCaret;
inputField.caretPosition=subId+1;
	CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void CaretLeftButtonAct(){
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
	subId = CaretPosSubId;
	inputField.caretPosition=subId;
int strLngth=inputField.text.Length;
if(subId==0){
}else{
inputField.caretPosition=subId-1;
}
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void CaretRightButtonAct(){
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
		subId = CaretPosSubId;
	inputField.caretPosition=subId;
int strLngth=inputField.text.Length;
if(subId==strLngth){
}else{
inputField.caretPosition=subId+1;
}
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void BackspaceButtonAct(){
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
	subId = CaretPosSubId;
	inputField.caretPosition=subId;
	string baseText = inputField.text;
if(subId==0){
}else{
	string bfrCaret = inputField.text.Substring(0,subId-1);
	string aftrCaret = inputField.text.Substring(subId);
	inputField.text = bfrCaret+aftrCaret;
inputField.caretPosition=subId-1;
}
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void DelButtonAct(){
	inputField.ActivateInputField();
	int subId = inputField.caretPosition;
	subId = CaretPosSubId;
	inputField.caretPosition=subId;
	string baseText = inputField.text;
int strLngth=inputField.text.Length;
if(subId==strLngth){
}else{
	string bfrCaret = inputField.text.Substring(0,subId);
	string aftrCaret = inputField.text.Substring(subId+1);
	inputField.text = bfrCaret+aftrCaret;
}
CaretPosSubId=inputField.caretPosition;
	inputField.DeactivateInputField();
}
public void ClearButtonAct(){
	inputField.ActivateInputField();
	inputField.caretPosition=0;
	inputField.text="";
	inputField.DeactivateInputField();
CaretPosSubId=inputField.caretPosition;
}
public void CancelButtonAct(){
DeactiveInputButton.GetComponent<Button>().onClick.Invoke();
	_joyInputON=false;
InputTypePanel.SetActive(false);
MainMenu.enabled=true;
	//inputField.ActivateInputField();
}
public void OkButtonAct(){
	_joyInputON=false;
InputTypePanel.SetActive(false);
MainMenu.enabled=true;
	inputField.ActivateInputField();
string finalTxt = inputField.text;
inputField.onEndEdit.Invoke(finalTxt);
}
public void CapslockButtonAct(){
CapslockOn= !CapslockOn;
if(!CapslockOn){
CapsColorBlock.pressedColor= basePressedColor;
CapsColorBlock.normalColor= baseNormColor;
CapslockInputButton.colors = CapsColorBlock;
}else{
CapsColorBlock.pressedColor= capslockOnPressColor;
CapsColorBlock.normalColor= capslockOnNormColor;
CapslockInputButton.colors = CapsColorBlock;
}
}
}
