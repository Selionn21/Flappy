using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private float jumpImpulse;
    [SerializeField] private bool jumpRequested = false;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private InputAction jumpAction;

    private void OnEnable() => jumpAction.Enable();

    private void OnDisable() => jumpAction.Disable();
    
        
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = 0f;
        velocity.z = 0f;

        if (jumpRequested)
        {
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            rb.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
            jumpRequested = false;
        }
        else rb.linearVelocity = velocity;
    }
}
