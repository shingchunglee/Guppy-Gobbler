using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  private SizeController sizeController;
  private EatingController eatingController;
  void Awake()
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
