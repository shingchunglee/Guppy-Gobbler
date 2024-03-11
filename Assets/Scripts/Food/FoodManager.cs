using UnityEngine;

public class FoodManager : MonoBehaviour
{
  private SizeController sizeController;
  private Food food;
  void Start()
  {
    sizeController = GetComponent<SizeController>();
    food = GetComponent<Food>();
    Init();
  }

  void Init(int size = 1)
  {
    sizeController.SetSize(size);
  }
}
