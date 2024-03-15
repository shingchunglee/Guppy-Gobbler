using UnityEngine;

public class DeathController : MonoBehaviour
{
  [SerializeField]
  private EatingController eatingController;
  void Start()
  {
    eatingController = GetComponent<EatingController>();
  }

  public void OnDeath()
  {
    Debug.Log("Dead");
    // TODO: Disable Inputs
    GetComponent<PlayerControllerMitch>().enabled = false;

    // Disable EatingController
    eatingController.enabled = false;

    // TODO: Show DeathScene
  }
}
