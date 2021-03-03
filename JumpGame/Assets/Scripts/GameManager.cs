using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour
{

    public static GameManager instance;

  

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        int jumpCounter = data.jumps;

        PlayerPrefs.SetFloat("X",data.position[0]);
        PlayerPrefs.SetFloat("Y",data.position[1]);
        PlayerPrefs.SetFloat("Z",data.position[2]);

        PlayerPrefs.SetInt("Jumps",jumpCounter);


      


        JumpsCounter.jumpValue = jumpCounter;


    }

    public void NewGame()
    {

       
        PlayerPrefs.SetFloat("X", -2.4f);
       PlayerPrefs.SetFloat("Y", -3.5f);
        PlayerPrefs.SetFloat("Z", 0f);
        PlayerPrefs.SetInt("Jumps", 0);
        PlayerPrefs.SetFloat("Time", 0);
       
        JumpsCounter.jumpValue = 0;
        
    }

   

  
}
