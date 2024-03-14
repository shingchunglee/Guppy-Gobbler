using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pauseIcon;
    public GameObject playIcon;
    bool paused = false;
    

    public void pausegame()
    {
        if (paused)
        {
            Time.timeScale = 1;
             pauseIcon.SetActive(true);
             playIcon.SetActive(false);
            paused = false;
        }
        else{
            Time.timeScale = 0;
            pauseIcon.SetActive(false);
             playIcon.SetActive(true);
            paused = true;
        }
    }
}
