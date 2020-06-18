using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTable : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Mushroom")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mushroom")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
