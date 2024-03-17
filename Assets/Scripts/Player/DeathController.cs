using UnityEngine;

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
  }
}
