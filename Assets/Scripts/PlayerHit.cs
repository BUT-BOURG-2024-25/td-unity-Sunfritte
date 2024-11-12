using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private float destroyTime = 2.0f; // Temps avant que le projectile soit détruit

    private void Start()
    {
        // Détruire le projectile après un certain temps
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet touché est un ennemi avec le tag "Cube"
        if (other.CompareTag("Cube"))
        {
            // Détruit le cube ennemi
            Destroy(other.gameObject);

            // Détruit le projectile lui-même après avoir touché l'ennemi
            Destroy(gameObject);
        }
    }
}