using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static float CurrentTime = 0f;
    //Make this 1 second higher than you think, it floors the time
    public const float START_TIME = 151f;
    private int _minutes;
    private int _seconds;

    public UIController ui;

    public TMP_Text timerText;

    private void Start()
    {
        CurrentTime = START_TIME;
        _minutes = Mathf.FloorToInt(CurrentTime / 60);
        _seconds = Mathf.FloorToInt(CurrentTime % 60);
        timerText.text = _minutes + ":" + _seconds.ToString("00");
    }

    private void Update()
    {
        //this is 1 instead of 0 because the seconds are floored and will display negative if it goes to 0
        if (CurrentTime > 1)
        {
            CurrentTime -= 1 * Time.deltaTime;
            _minutes = Mathf.FloorToInt(CurrentTime / 60);
            _seconds = Mathf.FloorToInt(CurrentTime % 60);
            timerText.text = _minutes + ":" + _seconds.ToString("00");
        }
        else
        {
            ui.Lose();
        }
    }
}
