using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;

    float time = 0;
    public bool on = true;

    void Update()
    {
        if(!on) return;

        time += Time.deltaTime;
        text.SetText(time.ToString("0.00"));
    }
}
