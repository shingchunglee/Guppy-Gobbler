using System.Collections;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class SpawnManager : MonoBehaviour
{

  [SerializeField]
  private Camera mainCamera;
  [SerializeField]
  private GameObject foodPrefab;
  [SerializeField]
  private SizeController playerSize;

  void Awake()
  {
    mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    playerSize = GameObject.FindWithTag("Player").GetComponent<SizeController>();

  }

  void Start()
  {
    // TODO: Update Delay
    StartCoroutine(SpawnFoodCoroutine(5f));
  }

  IEnumerator SpawnFoodCoroutine(float delay)
  {
    while (enabled)
    {
      yield return new WaitForSeconds(delay);
      SpawnFood();
    }
  }

  public void SpawnFood()
  {
    GameObject newFood = Instantiate(foodPrefab);

    if (newFood.TryGetComponent<FoodManager>(out FoodManager foodManager))
    {
      int size = GetRandomSize(playerSize.size);
      foodManager.Init(size, size * 100);

      UpdatePosition(newFood.GetComponent<Transform>(), size);
    }
  }

  private int GetRandomSize(int size)
  {
    return Random.Range(size - 2, size + 3);
  }

  private void UpdatePosition(Transform transform, int size)
  {
    float horizontalBorder = mainCamera.orthographicSize * Screen.width / Screen.height;
    float horizontalPos = horizontalBorder + size;
    int side = Random.Range(0, 2);
    if (side != 1)
    {
      horizontalPos *= -1;
    }

    transform.position = new Vector2(horizontalPos, getRandomHeight(size));
  }

  private float getRandomHeight(int size)
  {
    float verticalBorder = mainCamera.orthographicSize / (Screen.width / Screen.height);
    return Random.Range(-verticalBorder + size, verticalBorder - size);
  }
}
