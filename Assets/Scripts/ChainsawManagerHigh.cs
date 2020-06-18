using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawManagerHigh : MonoBehaviour
{
    public Door door;
    private int staticAmount;
    private int amount;
    // Start is called before the first frame update
    private void Awake()
    {
        amount = 0;
        staticAmount = 0;
    }
    
    public void initializationAmount()
    {
        staticAmount = staticAmount + 1;
        Debug.Log("Static amount = "+staticAmount);
    }

    public void addNumber()
    {
        amount = amount + 1;
        if(amount >= staticAmount)
        {
            door.setAccess();
        }
    }

}
