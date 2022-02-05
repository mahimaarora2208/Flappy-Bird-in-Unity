using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject prefab;
  public float spawnRate = 1f;
  public float maxHeight = 1f;
  public float minHeight = -1f;

    private void OnEnable()
    { // Only spawn when script is active
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    { 
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    { 
     // Clone prefab and introduce pipes with intial position and rotation
     GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
     pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
