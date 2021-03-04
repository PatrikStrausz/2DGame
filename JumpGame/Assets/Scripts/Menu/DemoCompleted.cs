using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoCompleted : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI jumpText;

    public TextMeshProUGUI demoTimeText;
    public TextMeshProUGUI demoJumpText;



    void Start()
    {
        demoJumpText.text = jumpText.text;
        demoTimeText.text = timeText.text;

    }

   
}
