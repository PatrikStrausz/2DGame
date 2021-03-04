using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpsCounter : MonoBehaviour
{

    public static int jumpValue = 0;
    TextMeshProUGUI jumps;

    void Start()
    {
        jumps = GetComponent<TextMeshProUGUI>();
       
    }

  
    void Update()
    {
        jumps.text = "Jumps: " + jumpValue;
    }
}
