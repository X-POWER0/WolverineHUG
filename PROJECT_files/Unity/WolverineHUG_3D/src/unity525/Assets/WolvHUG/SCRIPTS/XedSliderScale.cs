using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XedSliderScale : MonoBehaviour {
public Slider SliderX;
public void slideScaleX(float textUpdateNumber)
{
if ((textUpdateNumber > 0.79) && (textUpdateNumber < 0.81)) {
transform.localScale = new Vector3(1f, 0.8f, 1f);
}
else {
transform.localScale = new Vector3(1f, textUpdateNumber,1f);
}
}
}