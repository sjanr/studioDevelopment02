using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private float force = 10f;
    [SerializeField] private InputManager inputManager;
    private bool isBallLaunched;
    private Rigidbody ballRB;
    void Start()
    {
        // Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
