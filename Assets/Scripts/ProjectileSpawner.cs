using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Le prefab du projectile
    [SerializeField] private Transform spawnPoint; // Point d'origine du projectile
    [SerializeField] private float projectileSpeed = 10f; // Vitesse du projectile

    private void Start()
    {
        InputManager.Instance.RegisterOnClickInput(OnFire, true);
    }
    
    private void OnDestroy()
    {
        InputManager.Instance.RegisterOnClickInput(OnFire, false);
    }

    private void OnFire(InputAction.CallbackContext ctx)
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = spawnPoint.forward * projectileSpeed;
            }
        }
    }
}
