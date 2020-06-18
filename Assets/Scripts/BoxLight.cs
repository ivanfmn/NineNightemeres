using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLight : MonoBehaviour
{
    
    public void TurnColor()
    {
        StartCoroutine(SmoothColor(GetComponent<Renderer>(), GetComponent<Renderer>().material.GetColor("_EmissiveColor"), Color.white, 6f));
    }
    public void TurnColorBack()
    {
        StartCoroutine(SmoothColor(GetComponent<Renderer>(), GetComponent<Renderer>().material.GetColor("_EmissiveColor"), new Color(128,0,128), 3f));

    }

    IEnumerator SmoothColor(Renderer rend, Color startColor, Color endColor, float time ) 
    {
        float currTime = 0f;
        rend.material.color = startColor;
        do {
            rend.material.SetColor("_EmissiveColor", Color.Lerp(rend.material.color, endColor, currTime / time));
            currTime += Time.deltaTime;
            yield return null;
        } while (currTime<=time);
    }
}
