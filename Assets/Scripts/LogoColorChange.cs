using UnityEngine;
using UnityEngine.UI;

public class LogoColorChange : MonoBehaviour
{
    Color lerpedColor = Color.white;
    public Image logoImage;

    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, .5f));
        logoImage.color = lerpedColor;
    }
}