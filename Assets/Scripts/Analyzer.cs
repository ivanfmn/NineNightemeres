using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Analyzer : MonoBehaviour
{
    public AnalyzerManager analyzerManager;
    AudioSource audio;
    public float speed;
    public float newPositionX;
    float oldPositionX;
    bool isWork;
    bool addSpeed;

    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        isWork = false;
        addSpeed = false;
        oldPositionX = gameObject.transform.localPosition.x;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        
    }

    public void goMove()
    {
        if (!isWork) StartCoroutine(move());
    }
    public void goMoveandAddSpeed()
    {
        addSpeed = true;
        if (!isWork) StartCoroutine(move());
    }
    // Update is called once per frame
    IEnumerator move()
    {
        isWork = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        while(gameObject.transform.localPosition.x > newPositionX)
        {
            gameObject.transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
            yield return null;
        }
        addSpeed = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        while (gameObject.transform.localPosition.x < oldPositionX)
        {
            gameObject.transform.localPosition += new Vector3(speed*2 * Time.deltaTime, 0, 0);
            yield return null;
        }
        isWork = false;

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(move());
    }

    public void findEndFlower()
    {
        audio.Play();
        StopAllCoroutines();
        StartCoroutine(wait());
    }

    public void soil()
    {
        //audio
        StopAllCoroutines();
        StartCoroutine(wait());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Basket")
        {
            Debug.Log("yes");
            if (other.gameObject.GetComponent<Basket>().getGrowsEnd())
            {
                findEndFlower();
            }
            if(addSpeed)
            {
                other.GetComponent<Basket>().addSpeed();
                soil();
            }
        }
    }
}
