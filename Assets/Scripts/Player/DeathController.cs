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

    // Disable EatingController
    eatingController.enabled = false;

    // TODO: Show DeathScene
  }
}
