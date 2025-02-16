
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

private void SetPins()
{
    if (pinObjects != null)
    {
        foreach (Transform child in pinObjects.transform)
        {
            Debug.Log("Destroying child: " + child.name);  // Add this line
            Destroy(child.gameObject);
        }
        Debug.Log("Destroying parent: " + pinObjects.name);  // Add this line
        Destroy(pinObjects);
    }


    pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

    fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    foreach (FallTrigger pin in fallTriggers)
        pin.OnPinFall.AddListener(IncrementScore);
}



    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}








// using TMPro;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     [SerializeField] private float score = 0;
//     [SerializeField] private BallController ball;
//     [SerializeField] private GameObject pinCollection;
//     [SerializeField] private Transform pinAnchor;
//     [SerializeField] private InputManager inputManager;


//     [SerializeField] private TextMeshProUGUI scoreText;
//     private FallTrigger[] pins;
//     private GameObject pinObjects;
//     private void Start()
//     {
//         pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None); // New API

//         foreach (FallTrigger pin in pins) {
//             pin.OnPinFall.AddListener(IncrementScore);
//         }
//     }
//     private void HandleReset() {
//         ball.ResetBall();
//         SetPins();
//     }
//     private void SetPins() {
//         if(pinObjects) {

//         }
//     }
//     private void IncrementScore() {
//         score++;
//         scoreText.text = $"Score: {score}";
//     }
// }
