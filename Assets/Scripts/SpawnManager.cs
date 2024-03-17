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
  private GameObject[] foodPrefabs;
  [SerializeField]
  private SizeController playerSize;
  [SerializeField]
  private float delay = 5f;

  void Awake()
  {
    mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    playerSize = GameObject.FindWithTag("Player").GetComponent<SizeController>();

  }

  void Start()
  {
    // TODO: Update Delay
    StartCoroutine(SpawnFoodCoroutine(delay));
    StartCoroutine(SpawnSmallFoodCoroutine(delay + 0.5f));
  }

  IEnumerator SpawnSmallFoodCoroutine(float delay)
  {
    while (enabled)
    {
      yield return new WaitForSeconds(delay);
      SpawnSmallFood();
    }
  }

  private void SpawnSmallFood()
  {
    GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
    GameObject newFood = Instantiate(foodPrefab);

    if (newFood.TryGetComponent<FoodManager>(out FoodManager foodManager))
    {
      int size = GetRandomSmallSize(playerSize.size);
      foodManager.Init(size, size * 100);

      UpdatePosition(newFood.GetComponent<Transform>(), newFood.GetComponent<jellyfishMovement>(), size);

      if (size > playerSize.size)
      {
        newFood.GetComponent<OutlineController>().OutlineOn();
      }
      else
      {
        newFood.GetComponent<OutlineController>().OutlineOff();
      }
    }
  }

  private int GetRandomSmallSize(int size)
  {
    return Random.Range(1, size - 1);
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
    // Random.Range(1,2)
    // if random > 0.8 && playerSize.size > 5
    // spawn a non food instead
    GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
    GameObject newFood = Instantiate(foodPrefab);

    if (newFood.TryGetComponent<FoodManager>(out FoodManager foodManager))
    {
      int size = GetRandomSize(playerSize.size);
      foodManager.Init(size, size * 100);

      UpdatePosition(newFood.GetComponent<Transform>(), newFood.GetComponent<jellyfishMovement>(), size);

      if (size > playerSize.size)
      {
        newFood.GetComponent<OutlineController>().OutlineOn();
      }
      else
      {
        newFood.GetComponent<OutlineController>().OutlineOff();
      }
    }
  }

  private int GetRandomSize(int size)
  {
    return Random.Range(size - 2, size + 5);
  }

  private void UpdatePosition(Transform transform, jellyfishMovement jellyfishMovement, int size)
  {
    float horizontalBorder = mainCamera.orthographicSize * Screen.width / Screen.height;
    float horizontalPos = horizontalBorder + size;
    int side = Random.Range(0, 2);
    if (side != 1)
    {
      horizontalPos *= -1;
      jellyfishMovement.SetDirection(Vector2.right);
    }
    else
    {
      jellyfishMovement.SetDirection(Vector2.left);
    }

    transform.position = new Vector2(horizontalPos, getRandomHeight(size));
  }

  private float getRandomHeight(int size)
  {
    float verticalBorder = mainCamera.orthographicSize / (Screen.width / Screen.height);
    return Random.Range(-verticalBorder + size, verticalBorder - size);
  }
}
