using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawManagerLow : MonoBehaviour
{
    public ChainsawManagerHigh managerHigh;
    public GameObject[] pictures;
    public int[] idIndexes;
    private int[] curentIdIndexes;
    private int location;
    private int lengthMas;
    // Start is called before the first frame update
    private void Start()
    {
        managerHigh.initializationAmount();
        lengthMas = idIndexes.Length;
        location = 0;
        curentIdIndexes = new int[idIndexes.Length];
    }

    public void setIndexes(int id)
    {
            if (location < lengthMas)
            {
                curentIdIndexes[location] = id;
                location = location + 1;
            }
            if (location == lengthMas)
            {
                StartCoroutine(work());
            }
    }

    IEnumerator work()
    {
        yield return new WaitForSeconds(2f);
        if (compare())
        {
            Debug.Log("True");
            managerHigh.addNumber();
            apply();

        }
        else
        {
            Debug.Log("False");
            cancel();
        }
    }

    private bool compare()
    {
        for(int i = 0; i < idIndexes.Length; i++)
        {
            if(idIndexes[i] != curentIdIndexes[i])
            {
                return false;
            }
        }
        return true;
    }

    private void apply()
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            pictures[i].GetComponent<ChainsawPlane>().apply();
        }
    }
    private void cancel()
    {

        for(int i = 0; i < pictures.Length; i++)
        {
            pictures[i].GetComponent<ChainsawPlane>().cancel();
        }
        location = 0;
    }

}
