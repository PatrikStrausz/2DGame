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

    static Highscores instance;



    private static TimeSpan timePlaying;

    public Highscore[] highscoreList;

    DisplayHighScore displayHighScore;

    private void Awake()
    {
        instance = this;
        displayHighScore = GetComponent<DisplayHighScore>();
        AddNewHighScore("Dano");
        Download();
    }

    public static void AddNewHighScore(string username)
    {
        float elapsedTime = PlayerPrefs.GetFloat("Time");
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = timePlaying.ToString("mm''ss''ff");
        instance.StartCoroutine(instance.UploadNewHighscore(username, timePlayingStr));
    }

    IEnumerator UploadNewHighscore(string username, string time)
    {
    
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" +0+"/" +time);
       
       
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
            string time = entryInfo[2];
         
            
            highscoreList[i] = new Highscore(username, time);
            
        }
    }

    public struct Highscore
    {
        public string username;
        public string time;

        public Highscore(string username, string time)
        {
            this.username = username;
            this.time = time;
        }
    }
}
