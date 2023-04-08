using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Vector2 decisionTime = new Vector2(0, 2);
    private Transform thisTransform;
    private float decisionTimeCount;
    private Vector3[] moveDirections;
    private int currentMoveDirection;

    private void Awake()
    {
        thisTransform = transform;
        moveDirections = new Vector3[]
        {
        Vector3.right, Vector3.left, Vector3.forward, Vector3.back,
        new Vector3(1, 0, 1), new Vector3(-1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, -1)
        };
    }

    private void Start()
    {
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        ChooseMoveDirection();
    }

    private void Update()
    {
        var movement = moveDirections[currentMoveDirection];
        movement.y = 0f;
        thisTransform.position += movement * Time.deltaTime * moveSpeed;

        decisionTimeCount -= Time.deltaTime;
        if (decisionTimeCount <= 0f)
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChooseMoveDirection();
    }

    private void ChooseMoveDirection()
    {
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}