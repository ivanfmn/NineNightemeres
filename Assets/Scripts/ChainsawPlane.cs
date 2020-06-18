using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawPlane : MonoBehaviour
{
    public int id;
    public GameObject manager;
    private bool isPress;
    public float sizeVar;
    void Start()
    {
        isPress = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isPress == false)
        {
            isPress = true;
            manager.GetComponent<ChainsawManagerLow>().setIndexes(id);
            StartCoroutine(sizeUp());
        }
    }

    public void cancel()
    {
        StartCoroutine(sizeDown());
        isPress = false;
    }
    public void apply()
    {
        StartCoroutine(succesfull());
        gameObject.GetComponent<ChainsawPlane>().enabled = false;
    }

    private IEnumerator sizeUp()
    {
        for(float i = 0; i < 1f; i = i + 0.1f)
        {
            gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(sizeVar, sizeVar, sizeVar);
            yield return null;
        }
    }

    private IEnumerator succesfull()
    {
        for (float i = 1; i < 10f; i = i + 0.1f)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.white * 1.5f * i);
            yield return null;
        }
    }

    private IEnumerator sizeDown()
    {
        for (float i = 0; i < 1f; i = i + 0.1f)
        {
            gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(sizeVar, sizeVar, sizeVar);
            yield return null;
        }
    }

}
