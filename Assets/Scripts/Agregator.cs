using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Agregator : MonoBehaviour
{
    public int sumMushroom;

    public GameObject leftDoor;
    public GameObject rightDoor;
    public Transform createPosition;
    public GameObject creteObject;
    // Start is called before the first frame update
    private int currentSumMushroom;
    private float oldPosition;
    bool delete;
    private void Start()
    {
        delete = false;
        oldPosition = leftDoor.transform.localPosition.y;
       currentSumMushroom = 0;
    }

    public void onOpen()
    {
        StopAllCoroutines();
        StartCoroutine(open(leftDoor));
    }

    public void onClose()
    {
        StopAllCoroutines();
        StartCoroutine(close(leftDoor));
    }

    IEnumerator open(GameObject gameObject)
    {
        delete = false;
        float newPosition = oldPosition-0.3f;
        while(gameObject.transform.localPosition.y > newPosition)
        {
            gameObject.transform.localPosition -= new Vector3(0, 0.5f * Time.deltaTime, 0);
            yield return null;
        }
    }
    IEnumerator close(GameObject gameObject)
    {
        float newPosition = oldPosition;
        while (gameObject.transform.localPosition.y < newPosition)
        {
            gameObject.transform.localPosition += new Vector3(0, 0.5f * Time.deltaTime, 0);
            yield return null;
        }
        if(sign())
        {
            delete = true;
            StartCoroutine(waitAndCreate());
        }
        
    }

    IEnumerator waitAndCreate()
    {
        yield return new WaitForSeconds(5f);
        delete = false;
        Instantiate(creteObject, createPosition.position, createPosition.rotation);
        StartCoroutine(open(rightDoor));
    }

    IEnumerator waitAndClose()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(close(rightDoor));
    }

    private bool sign()
    {
        if (currentSumMushroom >= sumMushroom)
        {
            currentSumMushroom = 0;
            return true;
        }
        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mushroom")
        {
            currentSumMushroom++;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mushroom")
        {
            currentSumMushroom--;
        }
        if(other.tag == "MushroomFinish")
        {
            StartCoroutine(waitAndClose());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(delete && other.tag == "Mushroom")
        {
            Destroy(other.gameObject);
        }
    }

}
