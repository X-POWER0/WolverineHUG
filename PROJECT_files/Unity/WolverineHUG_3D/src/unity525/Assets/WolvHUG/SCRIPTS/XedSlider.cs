using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XedSlider : MonoBehaviour {
public Slider SliderX;

public void slidePosyX(float textUpdateNumber)
{
if ((textUpdateNumber > 0.79) && (textUpdateNumber < 0.81)) {
transform.localPosition = new Vector3(1f, 0.8f, 1f);
}
else {
transform.localPosition = new Vector3(1f, textUpdateNumber,1f);
}
}
}