using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DemoCompleted : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI jumpText;

    public TextMeshProUGUI demoTimeText;
    public TextMeshProUGUI demoJumpText;


    public  TMP_InputField inputField;

    private new string name;

   




    private void Update()
    {
        name = inputField.text;
    }



    void Start()
    {
      


        Time.timeScale = 0f;
        demoJumpText.text = jumpText.text;
        demoTimeText.text = timeText.text;

     


    }


    

    public void ResetRun()
    {
        PlayerPrefs.SetFloat("X", -2.4f);
        PlayerPrefs.SetFloat("Y", -3.5f);
       PlayerPrefs.SetFloat("Z", 0f);


        PlayerPrefs.SetInt("Jumps", 0);
        PlayerPrefs.SetFloat("Time", 0);

        JumpsCounter.jumpValue = 0;
    }


    public  void AddStats()
    {
       
      
        Highscores.instance.AddNewHighScore(name);
    }

}
