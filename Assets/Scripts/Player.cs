using UnityEngine;
public class Player : MonoBehaviour
{
  private SpriteRenderer spriteRenderer;  
  public Sprite[] sprites;
  private int spriteIndex;
  public float strength = 5f;
  public float gravity = -9.8f;       // Applies gravity on the bird which decides the game difficulty
  private Vector3 direction;

  private void Awake(){              // called automatically by unity and only called once
    spriteRenderer = GetComponent<SpriteRenderer>();
  } 
  
  private void Start(){
    InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // repeatedly call the function to animate sprite flying
  }
  private void OnEnable(){
    Vector3 position = transform.position;
    position.y = 0f;
    transform.position = position;
    direction = Vector3.zero;
  } 
  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
      direction = Vector3.up*strength;
    }

    if(Input.touchCount > 0){
      Touch touch = Input.GetTouch(0);
      
      if (touch.phase == TouchPhase.Began){
         direction = Vector3.up*strength;
      }
    } 
    direction.y += gravity * Time.deltaTime;
    transform.position += direction*Time.deltaTime; // time rate independant
  }

  private void AnimateSprite(){
    spriteIndex++;
    if(spriteIndex >= sprites.Length){
      spriteIndex = 0; // to start over the loop to move it continuously
    }
    spriteRenderer.sprite = sprites[spriteIndex];
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Obstacle"){
      FindObjectOfType<GameManager>().GameOver();
    }
    else if (other.gameObject.tag == "Scoring"){
      FindObjectOfType<GameManager>().IncreaseScore();
  }
}
}
