
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class ControlPinputField : MonoBehaviour {

	public pressedButtonM LeftKeyButtn;
	public pressedButtonM RightKeyButtn;	
	public pressedButtonM LeftCursorKeyButtn;
	public pressedButtonM RightCursorKeyButtn;
	public pressedButtonM UpKeyButtn;
	public pressedButtonM DownKeyButtn;
	public pressedButtonM SubmitKeyButtn;
	public pressedButtonM ExitKeyButtn;
	public pressedButtonM CapslocKeyButtn;
	public pressedButtonM OkKeyButtn;
	public pressedButtonM DelKeyButtn;
	public pressedButtonM ClearKeyButtn;
	public pressedButtonM BackspaseKeyButtn;
	public pressedButtonM SpaceKeyButtn;
	public pressedButtonM CancelKeyButtn;

	public pressedButtonM IKeyButtn, IIKeyButtn, IIIKeyButtn, IVKeyButtn, VKeyButtn, VIKeyButtn, VIIKeyButtn, VIIIKeyButtn, IXKeyButtn, ZeroKeyButtn;
	public pressedButtonM LParenthKeyButtn, RParenthKeyButtn, LSqrBracketKeyButtn, RSqrBracketKeyButtn, LFgrBracketKeyButtn, RFgrBracketKeyButtn, SemicolonKeyButtn, ColonKeyButtn;
	public pressedButtonM BackTickKeyButtn, TildeKeyButtn, ExclamationKeyButtn, AtKeyButtn, NumberKeyButtn, DolrKeyButtn, PercentKeyButtn, CircumflexKeyButtn,  AmpersandKeyButtn,  AsteriskKeyButtn, UnderscoreKeyButtn, PlusKeyButtn, MinusKeyButtn, EqualKeyButtn, SlashKeyButtn, BackSlashKeyButtn, PipeKeyButtn, QuestionKeyButtn;
	public pressedButtonM QKeyButtn, WKeyButtn, EKeyButtn, RKeyButtn, TKeyButtn, YKeyButtn, UKeyButtn, iKeyButtn, OKeyButtn, PKeyButtn, PrimeKeyButtn, QuoteKeyButtn, ComaKeyButtn, DotKeyButtn;
	public pressedButtonM AKeyButtn, SKeyButtn, DKeyButtn, FKeyButtn, GKeyButtn, HKeyButtn, JKeyButtn, KKeyButtn, LKeyButtn;
	public pressedButtonM ZKeyButtn, XKeyButtn, CKeyButtn, vKeyButtn, BKeyButtn, NKeyButtn, MKeyButtn;

[SerializeField] private bool ControlPanelON=false;
public bool SetControlPanelON {
//c#7
//    get=> _selectedMenuButton;
//    set=> _selectedMenuButton = value;
	get { return ControlPanelON;}
    set { ControlPanelON = value;}

}
private pressedButtonM[] keyCodes;
public static event Action<PressedKeyCode[]> KeyPressed;

private void Awake(){
	keyCodes = new[]{
	LeftKeyButtn,
	RightKeyButtn,
	LeftCursorKeyButtn,
	RightCursorKeyButtn,
	CapslocKeyButtn,
	OkKeyButtn,
	DelKeyButtn,
	ClearKeyButtn,
	BackspaseKeyButtn,
	SpaceKeyButtn,
	CancelKeyButtn,
	IKeyButtn, IIKeyButtn, IIIKeyButtn, IVKeyButtn, VKeyButtn, VIKeyButtn, VIIKeyButtn, VIIIKeyButtn, IXKeyButtn, ZeroKeyButtn,
	LParenthKeyButtn, RParenthKeyButtn, LSqrBracketKeyButtn, RSqrBracketKeyButtn, LFgrBracketKeyButtn, RFgrBracketKeyButtn, SemicolonKeyButtn, ColonKeyButtn,
	BackTickKeyButtn, TildeKeyButtn, ExclamationKeyButtn, AtKeyButtn, NumberKeyButtn, DolrKeyButtn, PercentKeyButtn, CircumflexKeyButtn, AmpersandKeyButtn, AsteriskKeyButtn, UnderscoreKeyButtn, PlusKeyButtn, MinusKeyButtn, EqualKeyButtn, SlashKeyButtn, BackSlashKeyButtn, PipeKeyButtn, QuestionKeyButtn,
	QKeyButtn, WKeyButtn, EKeyButtn, RKeyButtn, TKeyButtn, YKeyButtn, UKeyButtn, iKeyButtn, OKeyButtn, PKeyButtn, PrimeKeyButtn, QuoteKeyButtn, ComaKeyButtn, DotKeyButtn,
	AKeyButtn, SKeyButtn, DKeyButtn, FKeyButtn, GKeyButtn, HKeyButtn, JKeyButtn, KKeyButtn, LKeyButtn,
	ZKeyButtn, XKeyButtn, CKeyButtn, vKeyButtn, BKeyButtn, NKeyButtn, MKeyButtn
	};
}
	void FixedUpdate () {
	List<PressedKeyCode> pressedKeyCode = new List<PressedKeyCode>();
	for(int index=0; index < keyCodes.Length; index++)
	{
		pressedButtonM keyCode = keyCodes[index];
		if(keyCode.isPressed){
			pressedKeyCode.Add((PressedKeyCode)index);
		}
		if(KeyPressed != null)
		KeyPressed(pressedKeyCode.ToArray());
	}
	}
}
