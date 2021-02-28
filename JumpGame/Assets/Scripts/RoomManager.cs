using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomManager : MonoBehaviour
{

    public GameObject virtualCam;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(true);

            CameraShake.Instance = virtualCam.GetComponent<CameraShake>();
       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(false);
          
        }
    }
}
