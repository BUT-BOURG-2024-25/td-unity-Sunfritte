using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCube : MonoBehaviour
{

    [SerializeField] private LayerMask GroundLayer;
    
    private void Start()
    {
        InputManager.Instance.RegisterOnClickInput(OnClick, true);
    }
    
    private void OnDestroy()
    {
        InputManager.Instance.RegisterOnClickInput(OnClick, false);
    }

    private void OnClick(InputAction.CallbackContext ctx)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000, GroundLayer);

        if (raycastHasHit)
        {
            if (hitInfo.collider.CompareTag("Cube"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}