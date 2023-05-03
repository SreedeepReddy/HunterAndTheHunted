using UnityEngine;
using UnityEngine.AI;

public class NPCMovementScript : MonoBehaviour
{

    GameObject hunter;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer;

    // roam
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float Walkrange;

    public float moveSpeed = 3f;
    [SerializeField] private Vector2 decisionTime = new Vector2(0, 2);
    private Transform thisTransform;
    private float decisionTimeCount;
    private Vector3[] moveDirections;
    private int currentMoveDirection;

    public CharacterController npcCntrl;

    //private void Awake()
    //{
    //    thisTransform = transform;
    //    moveDirections = new Vector3[]
    //    {
    //    Vector3.right, Vector3.left, Vector3.forward, Vector3.back,
    //    new Vector3(1, 0, 1), new Vector3(-1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, -1),
    //    new Vector3(0, 0, 0)
    //    };
    //}

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        //npcCntrl = GetComponent<CharacterController>();
        //ChooseMoveDirection();
    }

    private void Update()
    {
        Roam();
        //Vector3 moveVect = Vector3.zero;
        //var movement = moveDirections[currentMoveDirection];
        //movement.y = 0f;
        ////thisTransform.position += movement * Time.deltaTime * moveSpeed;
        //moveVect = movement * Time.deltaTime * moveSpeed;
        //npcCntrl.SimpleMove(moveVect);
        //decisionTimeCount -= Time.deltaTime;
        //if (decisionTimeCount <= 0f)
        //{
        //    decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        //    ChooseMoveDirection();
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChooseMoveDirection();
    }

    private void ChooseMoveDirection()
    {
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }

    void Roam()
    {
        if (!walkpointSet) 
            GetRandDest();
        if (walkpointSet)
            agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10)
            walkpointSet = false;
    }

    void GetRandDest()
    {
        float z = Random.Range(-Walkrange, Walkrange);
        float x = Random.Range(-Walkrange, Walkrange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}