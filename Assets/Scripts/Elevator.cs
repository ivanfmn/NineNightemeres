using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject HandUp;
    public GameObject PlaneUp;

    GameObject flower;

    public float moveHand;
    public float movePLaneUp;
    public float speed;

    bool isWork;
    bool press;
    // Start is called before the first frame update

    private void Start()
    {
        isWork = false;
        flower = null;
    }

    public void onOpenHandUp()
    {
        if(!isWork)
        {
            StartCoroutine(openHand());
        }
    }
    public void onMovePlaneUp()
    {
        if(!isWork && !press)
        {
            StartCoroutine(movePlaneUp());
        }
    }
    public void onCloseHandUp()
    {
        if(isWork)
        {
            StartCoroutine(closeHandUp());
        }
        
    }
    IEnumerator openHand()
    {
        isWork = true;
        float newPositionY = HandUp.transform.localPosition.y+ moveHand;
        while(HandUp.transform.localPosition.y < newPositionY)
        {
            HandUp.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
    IEnumerator closeHandUp()
    {
        float oldPositionY = HandUp.transform.localPosition.y - moveHand;
        while (HandUp.transform.localPosition.y > oldPositionY)
        {
            HandUp.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
        isWork = false;
    }
    IEnumerator movePlaneUp()
    {
        press = true;
        float oldPositionY = PlaneUp.transform.localPosition.y;
        float newPositionY = oldPositionY + movePLaneUp;
        while (PlaneUp.transform.localPosition.y < newPositionY)
        {
            PlaneUp.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (PlaneUp.transform.localPosition.y > oldPositionY)
        {
            PlaneUp.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
        press = false;
    }
}
