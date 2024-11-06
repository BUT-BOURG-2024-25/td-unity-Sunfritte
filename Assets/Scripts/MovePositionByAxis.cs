using UnityEngine;
using UnityEngine.InputSystem;


public class MovePositionByAxis : MonoBehaviour
{

    [SerializeField] private float Speed = 5.2f;
    [SerializeField] private Rigidbody physicsBody;
    [SerializeField] private float JumpPower = 20f;


    private void Start()
    {
        InputManager.Instance.RegisterOnJumpInput(Jump,true);
    }
    
    private void OnDestroy()
    {
        InputManager.Instance.RegisterOnJumpInput(Jump,false);
    }

    void Update()
    {
        
        /*
         * Partie 1
         */
        
        // float Horizontal = Input.GetAxis("Horizontal");
        // float HorizontalRaw = Input.GetAxisRaw("Horizontal");
        //
        // float Vertical = Input.GetAxis("Vertical");
        // float VerticalRaw = Input.GetAxisRaw("Vertical");
        //
        // Debug.Log("Horizontal : " + Horizontal + " + HorizontalRaw : ");
        // Debug.Log("Vertical : " + Vertical + " + VerticalRaw + ");
        //
        // Vector3 Movement = new Vector3(Horizontal, 0, Vertical);
        
        // gameObject.transform.position += Movement * (Speed * Time.deltaTime);

        
        /*
         * Partie 2
         */
        
        // gameObject.transform.position += InputManager.Instance.MovementInput * (Speed * Time.deltaTime);
            
        /*
         * Partie 3
         */

        Vector3 NewVelocity = InputManager.Instance.MovementInput * Speed ;
        NewVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = NewVelocity;
        // physicsBody.velocity = InputManager.Instance.MovementInput * Speed;

    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up *JumpPower);
    }
}
