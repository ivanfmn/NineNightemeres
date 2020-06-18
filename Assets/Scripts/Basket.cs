using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject flower;
    public float endTime;
    public float speed;
    bool growsEnd;
    float bitTime;
    bool isSpeed;
    float delta;
    float oldSpeed;

    void Start()
    {
        isSpeed = false;
        speed *= Random.Range(0.5f, 2f);
        oldSpeed = speed;
        endTime *= Random.Range(0.5f, 3);
        growsEnd = false;
        bitTime = 1 / endTime;
        delta = Time.deltaTime;
        flower.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        StartCoroutine(growsUp());
    }
    public void addSpeed()
    {
        if(!isSpeed)
        {
            speed = speed * 10;
            oldSpeed = speed;
            isSpeed = true;
        }
    }
    public void speedLight(bool turnSpeed)
    {
        if(turnSpeed)
        {
            speed = speed * 10;
        }
        else
        {
            speed = oldSpeed;
        }
        
    }

    public bool getGrowsEnd()
    {
        return growsEnd;
    }

    public void plusSpeed(float speed)
    {
        this.speed *= speed;
    }

    IEnumerator growsUp()
    {
        float currentGrows = 0;
        for(float i = 0; i < endTime; i += bitTime*speed)
        {
            currentGrows = i * bitTime;
            flower.gameObject.transform.localScale =new Vector3(currentGrows, currentGrows, currentGrows);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        growsEnd = true;
        Debug.Log(growsEnd);
    }
}
