using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Highscores : MonoBehaviour
{

    const string privateCode = "jyWH912r2UCJOCTzxUJeBAc893Xch7mEG9SIwmZgJDzw";
    const string publicCode = "6046540f8f40bbbd0cc3a147";
    const string webURL = "http://dreamlo.com/lb/";

   public static Highscores instance;

    private long score = 1000000000000000000;

    private static TimeSpan timePlaying;

    public Highscore[] highscoreList;

    DisplayHighScore displayHighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
      
        displayHighScore = GetComponent<DisplayHighScore>();
        Download();
    }

    public  void AddNewHighScore(string username)
    {
        score = 1000000000000000000;
        float elapsedTime = PlayerPrefs.GetFloat("Time");
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        
        score = score - timePlaying.Ticks;
        Debug.Log("SCORE: " + score);
        string timePlayingStr = timePlaying.ToString("mm''ss''ff");

      
        instance.StartCoroutine(instance.UploadNewHighscore(username, timePlayingStr));
        Download();
    }

    IEnumerator UploadNewHighscore(string username, string time)
    {
    
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" +score+"/" +time);
       
       
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful");
            Download();
        }
        else
        {
            Debug.Log("Error: " + www.error);
        }
    }


    public void Download()
    {
       
        StartCoroutine(DownloadHighscore());
    }

    IEnumerator DownloadHighscore()
    {
     
        UnityWebRequest www =  UnityWebRequest.Get(webURL + publicCode + "/pipe/");

      
        yield return www.SendWebRequest(); 

        if (string.IsNullOrEmpty(www.error))
        {
            
            FormatHighScores(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);
            displayHighScore.HighscoresDownloaded(highscoreList);
        }
        else
        {
            Debug.Log("Error: " + www.error);
        }
    }


    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        highscoreList = new Highscore[entries.Length];
        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            string score = entryInfo[1];
            string time = entryInfo[2];
         
            
            highscoreList[i] = new Highscore(username, time, score);
            
        }
    }

    public struct Highscore
    {
        public string username;
        public string time;
        public string score;

        public Highscore(string username, string time, string score)
        {
            this.username = username;
            this.time = time;
            this.score = score;
          
        }
    }
}
