using UnityEngine;

public class Parallax : MonoBehaviour
{
   public float animationSpeed = 1f;
   private MeshRenderer MeshRenderer;

   private void Awake(){
       MeshRenderer = GetComponent<MeshRenderer>();
   }
   private void Update()
   {
       MeshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0); // To make it framerate independent
   }
}
