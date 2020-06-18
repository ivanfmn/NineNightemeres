using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManagerHigh : MonoBehaviour
{
    // Start is called before the first frame update
    public Door door;
    public SheetMove sheetMove;

    public void setOpenDoor()
    {
        door.setAccess();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MushroomFinish")
        {
            Destroy(other.gameObject);
            if(!door.getAccess()) sheetMove.onMoveDoor();
        }
    }
}
