using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDustManager : MonoBehaviour
{

    public GameObject dustSmall;
    public GameObject dustBig;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            dustSmall.SetActive(true);
            dustBig.SetActive(true);

           

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            dustSmall.SetActive(false);
            dustBig.SetActive(false);

        }
    }
}
