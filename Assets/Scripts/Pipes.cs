using UnityEngine;

public class Pipes : MonoBehaviour
{
 public float speed = 5f;
 private float leftEdge;

 private void Start()
 {
     // convert screen space coorditates to world space coordinates
     leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
 }
 private void Update()
 {
     transform.position += Vector3.left * speed * Time.deltaTime;
     if (transform.position.x < leftEdge)
     {
         Destroy(gameObject);
     }
 }

}
