using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    [SerializeField] private Vector2 decisionTime = new Vector2(0, 2);
    private Transform thisTransform;
    private float decisionTimeCount;
    private Vector3[] moveDirections;
    private int currentMoveDirection;

    public CharacterController npcCntrl;

    private void Awake()
    {
        thisTransform = transform;
        moveDirections = new Vector3[]
        {
        Vector3.right, Vector3.left, Vector3.forward, Vector3.back,
        new Vector3(1, 0, 1), new Vector3(-1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, -1),
        new Vector3(0, 0, 0)
        };
    }

    private void Start()
    {
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        npcCntrl = GetComponent<CharacterController>();
        ChooseMoveDirection();
    }

    private void Update()
    {
        Vector3 moveVect = Vector3.zero;
        var movement = moveDirections[currentMoveDirection];
        movement.y = 0f;
        //thisTransform.position += movement * Time.deltaTime * moveSpeed;
        moveVect = movement * Time.deltaTime * moveSpeed;
        npcCntrl.SimpleMove(moveVect);
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