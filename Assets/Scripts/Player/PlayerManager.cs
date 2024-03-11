using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  private SizeController sizeController;
  private EatingController eatingController;
  void Start()
  {
    sizeController = GetComponent<SizeController>();
    eatingController = GetComponent<EatingController>();
    Init();
  }

  void Init()
  {
    sizeController.SetSize(3);
  }
}
