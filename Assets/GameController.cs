using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerControllerMitch PlayerController;

    public Canvas GameOverCanvas;

    private void Awake()
    {

        if(PlayerController != null)
        {
            PlayerController.PlayerDied += whenPlayerDies;

        }


        if (GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);

        }
    }


    void whenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);

        if (PlayerController != null)
        {
            PlayerController.PlayerDied -= whenPlayerDies;

        }
    }



    public void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
