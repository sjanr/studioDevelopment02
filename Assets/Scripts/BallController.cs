using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator;
    private bool isBallLaunched;
    private Rigidbody ballRB;
    void Start() {
        ballRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ResetBall();
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        // ballRB.AddForce(transform.forward * force, ForceMode.Impulse);

    }
    public void ResetBall() {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
