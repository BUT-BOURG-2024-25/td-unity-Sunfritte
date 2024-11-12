using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyBehavior : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTransform;

    private void Start()
    {
        // Cherche le joueur dans la scène via son tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * (speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si l'ennemi touche le joueur, recharger la scène
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
