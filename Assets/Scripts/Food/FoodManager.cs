using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FoodManager : MonoBehaviour
{
  private SizeController sizeController;
  private ScoreController scoreController;
  private Food food;
  void Awake()
  {
    sizeController = GetComponent<SizeController>();
    scoreController = GetComponent<ScoreController>();
    food = GetComponent<Food>();
  }

  public void Init(int size = 1, int score = 100)
  {
    sizeController.SetSize(size);
    scoreController.SetScore(score);
  }
}
