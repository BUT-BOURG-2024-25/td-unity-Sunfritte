using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCube : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn = null;

    [SerializeField] private LayerMask GroundLayer;
    
    private void Start()
    {
        InputManager.Instance.RegisterOnClickInput(OnCLick,true);
    }
    
    private void OnDestroy()
    {
        InputManager.Instance.RegisterOnClickInput(OnCLick,false);
    }

    private void OnCLick(InputAction.CallbackContext ctx)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool raycastHasHit = Physics.Raycast(cameraRay,out hitInfo,10000,GroundLayer);

        if (raycastHasHit && objectToSpawn != null)
        {
            GameObject.Instantiate(objectToSpawn,hitInfo.point+(Vector3.up*0.5f),Quaternion.identity);
        }
    }
    
   
}
