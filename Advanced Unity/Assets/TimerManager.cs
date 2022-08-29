using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : Singleton<TimerManager >
{
    public double CurrentDuration;

    public IEnumerator timer(double Duration)                                // ajastin, jonka jälkeen vihollinen menee spot objectille
    {
        CurrentDuration = Duration;
        while (CurrentDuration  > 0)
        {

            yield return new WaitForSeconds(1.0f);
            CurrentDuration--;
        }
        if (CurrentDuration <= 0)
        {
            

        }


    }

}
