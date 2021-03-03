using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public void PlayHighlightSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSelect");
    }
}
