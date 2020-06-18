using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManagerHigh : MonoBehaviour
{
    public Door door;
    bool finish;

    private void Start()
    {
        finish = false;
    }
    // Start is called before the first frame update
    private void opendoor()
    {
        if(!finish)
        {
            door.setAccess();
            finish = true;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Basket")
        {
            if(other.GetComponent<Basket>().getGrowsEnd())
            {
                Destroy(other.gameObject);
                opendoor();
            }
        }
    }
}
