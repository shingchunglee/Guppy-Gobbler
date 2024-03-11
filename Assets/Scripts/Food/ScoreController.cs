using UnityEngine;

public class ScoreController : MonoBehaviour
{
  public int score { private set; get; }

  public void SetScore(int newScore)
  {
    score = newScore;
  }
}
