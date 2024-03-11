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

  }
}
