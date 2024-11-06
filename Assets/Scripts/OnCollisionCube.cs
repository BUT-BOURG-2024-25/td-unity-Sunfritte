using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Cube"))
        {
            
            Destroy(collision.gameObject);
        }
    }
}