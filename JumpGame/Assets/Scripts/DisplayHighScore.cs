using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{

    public TextMeshProUGUI[] highscoreText;
    Highscores highscoreManager;

    private void Start()
    {
        for(int i=0; i<highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }

        highscoreManager = GetComponent<Highscores>();
        highscoreManager.Download();

        StartCoroutine(RefreshHighScores());
    }

   
    public void HighscoresDownloaded(Highscores.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i  +1+ ". ";
            if(highscoreList.Length > i)
            {
                string time = "";

             

                if (highscoreList[i].time.Length > 6)
                {
                    time = highscoreList[i].time.Substring(0, 2) + ":" +
                       highscoreList[i].time.Substring(2,2) + ":"+
                       highscoreList[i].time.Substring(4, 2);

                }
                else if (highscoreList[i].time.Length < 2)
                {
                    time = "00:00:0" + highscoreList[i].time.Substring(0, 1);
                }
                else if(highscoreList[i].time.Length < 3)
                {
                    time = "00:00:" + highscoreList[i].time.Substring(0, 2);
                }
                else if(highscoreList[i].time.Length < 4)
                {
                    time = "00:0" + highscoreList[i].time.Substring(0, 1) +":"+ highscoreList[i].time.Substring(1, 2);
                }else if(highscoreList[i].time.Length < 5)
                {
                    time = "00:"+highscoreList[i].time.Substring(0, 2) + ":" +
                     highscoreList[i].time.Substring(2, 2);
                }
                else if (highscoreList[i].time.Length < 6)
                {
                    time = "0" + highscoreList[i].time.Substring(0, 1) + ":" +
                     highscoreList[i].time.Substring(2, 2) + ":" +
                       highscoreList[i].time.Substring(4, 2); ;
                }

                highscoreText[i].text += highscoreList[i].username + "   " + time;
            }
        }
    }


    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highscoreManager.Download();
            yield return new WaitForSeconds(30);
        }
    }
}
