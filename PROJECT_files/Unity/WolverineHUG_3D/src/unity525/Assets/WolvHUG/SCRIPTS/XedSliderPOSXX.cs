using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XedSliderPOSXX : MonoBehaviour {
public Slider SliderX;
public void slidePoseXy(float textUpdateNumber)
{
if ((textUpdateNumber > 0.79) && (textUpdateNumber < 0.81)) {
transform.localPosition = new Vector3(1f, -15.1f, 1f);
}
else {
transform.localPosition = new Vector3(1f, textUpdateNumber,1f);
}
}
}