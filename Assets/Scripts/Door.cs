using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //public GameObject light;
    public Renderer enterLight;
    public AudioClip open;
    AudioSource audioSource;
    Animator animation;
    public bool access;
    public float waitTime;
    private bool isOpen;

    void Start()
    {
        enterLight.material.SetColor("_EmissiveColor", Color.black);
        isOpen = false;
        audioSource = GetComponent<AudioSource>();
        if (access) setAccess();
        animation = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && access == true && isOpen == false)
        {
            isOpen = true;
            animation.SetBool("setOpen", true);
            audioSource.PlayOneShot(open);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && access == true && isOpen == true)
        {
            isOpen = false;
            StartCoroutine(wait(waitTime));
        }
    }

    private IEnumerator onEnterLight()
    {
        for (float i = 0; i < 10f; i = i + 0.15f)
        {
            enterLight.material.SetColor("_EmissiveColor", Color.white * 1.5f * i);
            yield return null;
        }
    }

    private IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animation.SetBool("setOpen", false);
        audioSource.PlayOneShot(open);
    }

    public void setAccess()
    {
        access = true;
        StartCoroutine(onEnterLight());
        //light.GetComponent<Material>().SetColor("_EmissionColor", new Color(.5F, .3F, .7F, 1F));
    }
    public bool getAccess()
    {
        return access;
    }
}
