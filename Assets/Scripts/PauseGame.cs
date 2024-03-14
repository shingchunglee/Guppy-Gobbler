using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool paused = false;

    public void pausegame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else{
            Time.timeScale = 0;
            paused = true;
        }
    }
}
