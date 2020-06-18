using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMove : MonoBehaviour
{
    public GameObject door;
    public MushroomManagerHigh managerHigh;
    // Start is called before the first frame update
    public void onMoveDoor()
    {
        StartCoroutine(openDoor());
    }

    IEnumerator openDoor()
    {
        //audio
        float newPosition = door.transform.localPosition.z + 0.018f;
        while (door.transform.localPosition.z < newPosition)
        {
            door.transform.localPosition += new Vector3(0, 0, 0.5f * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator disenfection()
    {
        yield return new WaitForSeconds(3f);
        float newPosition = door.transform.localPosition.z - 0.018f;
        while (door.transform.localPosition.z > newPosition)
        {
            door.transform.localPosition -= new Vector3(0, 0, 0.5f * Time.deltaTime);
            yield return null;
        }
        //sound
        yield return new WaitForSeconds(8f);
        managerHigh.setOpenDoor();
        StartCoroutine(openDoor());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(disenfection());
        }
    }
}
