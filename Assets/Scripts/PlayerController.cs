using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
        
    }
    private void MovePlayer(Vector2 direction) {
        Debug.Log($"MovePlayer called with direction: {direction}");
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection);

        Debug.Log($"Speed: {rb.linearVelocity.magnitude}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
