using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;     // L'objet ennemi à instancier
    [SerializeField] private BoxCollider spawnArea;        // Zone de spawn (délimitée par un BoxCollider)
    [SerializeField] private float minDistanceToPlayer = 5f; // Distance minimale avec le joueur
    [SerializeField] private Vector2 spawnIntervalRange = new Vector2(1f, 5f); // Plage de temps pour les spawns

    private Transform playerTransform;

    private void Start()
    {
        // Trouve le joueur avec le tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        // Démarre la coroutine de spawn d'ennemis
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Choisit un délai de spawn aléatoire dans la plage spécifiée
            float spawnDelay = Random.Range(spawnIntervalRange.x, spawnIntervalRange.y);
            yield return new WaitForSeconds(spawnDelay);

            // Génère une position de spawn aléatoire dans la zone définie
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Instancie l'ennemi à la position générée
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition;
        float distanceToPlayer;

        do
        {
            // Crée une position aléatoire dans les limites du BoxCollider
            float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
            randomPosition = new Vector3(x, spawnArea.bounds.center.y, z);

            // Calcule la distance entre cette position et le joueur
            distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position);

        } while (distanceToPlayer < minDistanceToPlayer); // Vérifie la distance minimale

        return randomPosition;
    }
}
