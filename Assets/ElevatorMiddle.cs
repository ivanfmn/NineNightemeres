using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMiddle : MonoBehaviour
{
    public Transform transform;
    public GameObject player;
    public Animator circle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        gameObject.GetComponent<Animator>().SetBool("move", true);
        player.transform.parent = gameObject.transform;
        float delta = transform.position.y - gameObject.transform.position.y;
        delta = (delta * 0.7f)+ gameObject.transform.position.y;
        yield return new WaitForSeconds(3);
        while(gameObject.transform.position.y < transform.position.y)
        {
            if(gameObject.transform.position.y > delta)
            {
                circle.SetTrigger("open");
            }
            gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
        player.transform.parent = null;
        gameObject.GetComponent<Animator>().SetBool("move", false);
    }
}
