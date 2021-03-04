
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Animator transition;

    public Button loadButton;

    private void Start()
    {
        string path = Application.persistentDataPath + "/player.bin";

        if (File.Exists(path)){
            loadButton.enabled = true;
        }
        else
        {
            loadButton.enabled = false;
        }
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPressed");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPressed");
        Debug.Log("Quit");
        Application.Quit();
    }



   IEnumerator LoadLevel(int levelIndex)
    {
        FindObjectOfType<AudioManager>().Play("ButtonPressed");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
