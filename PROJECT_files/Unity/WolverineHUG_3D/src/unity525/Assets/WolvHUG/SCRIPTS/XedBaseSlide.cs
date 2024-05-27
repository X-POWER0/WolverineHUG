using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class XedBaseSlide : MonoBehaviour {

string sliderTargetString = "500";
public int XedValmax;
public Text sliderText;
public Slider mainSlider;
public GameObject sliderTarget;

void Awake(){
mainSlider.maxValue = XedValmax;
}
	void Update(){
		if (Input.GetAxisRaw("Vertical")>0){
			if(mainSlider.value<XedValmax){
				mainSlider.value += 1f;}
		}
		else if (Input.GetAxisRaw("Vertical")<0){
			if(mainSlider.value>mainSlider.minValue){
				mainSlider.value -= 1f;}
		}
	}
public void textUpdate(float textUpdateNumber)
{
sliderTargetString = textUpdateNumber.ToString();
sliderText.text = sliderTargetString;
}
public void textUpdatePose(float textUpdateNumber)
{
transform.localPosition = new Vector3(1f, textUpdateNumber,1f);
}
}