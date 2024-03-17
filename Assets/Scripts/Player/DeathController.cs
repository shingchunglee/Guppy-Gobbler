using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
  [SerializeField]
  private EatingController eatingController;

  [SerializeField]
  private Sprite deadSprite;
  private SpriteRenderer spriteRenderer;


  void Awake()
  {
    eatingController = GetComponent<EatingController>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  public void OnDeath()
  {
    Debug.Log("Dead");
    // TODO: Disable Inputs
    GetComponent<PlayerControllerMitch>().enabled = false;

    // Disable EatingController
    eatingController.enabled = false;

    // use dead sprite
    spriteRenderer.sprite = deadSprite;

    // TODO: Show DeathScene
    StartCoroutine(ShowMainMenuScene(3f));
  }

  IEnumerator ShowMainMenuScene(float delay)
  {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadSceneAsync(0);
  }
}
