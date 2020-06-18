using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLightManager : MonoBehaviour
{
    public BoxLight[] boxLights;
    bool isPress;
    bool work;
    bool speed;
    private void Start()
    {
        work = false;
        speed = true;
        isPress = false;
    }
    public void pressBack()
    {
        if(!work)
        {
            StopAllCoroutines();
            StartCoroutine(TurnColorBack());
            speed = true;
            StartCoroutine(turnSpeed());
        }
        
    }
    public void pressColor()
    {
        if(!work)
        {
            StopAllCoroutines();
            StartCoroutine(TurnColor());
            speed = false;
            StartCoroutine(turnSpeed());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Basket")
        {
            other.GetComponent<Basket>().speedLight(speed);
        }
    }
    IEnumerator TurnColor()
    {
        work = true;
        for (int i = 0; i < boxLights.Length; i++)
        {
            boxLights[i].TurnColor();
            yield return new WaitForSeconds(2f);
        }
        work = false;
    }
    IEnumerator TurnColorBack()
    {
        work = true;
        for(int i = 0; i < boxLights.Length; i++)
        {
            boxLights[i].TurnColorBack();
            yield return new WaitForSeconds(2f);
        }
        work = false;
    }
    IEnumerator turnSpeed()
    {
        float y = gameObject.transform.position.y;
        while(y + gameObject.transform.position.y > -10)
        {
            gameObject.transform.position -= new Vector3(0, Time.deltaTime * 10, 0);
            yield return null;
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, gameObject.transform.position.z);
    }

}
