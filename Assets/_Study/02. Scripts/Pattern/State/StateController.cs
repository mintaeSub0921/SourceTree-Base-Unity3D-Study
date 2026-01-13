
using UnityEngine;



public class StateController : MonoBehaviour
{
    private IState currentState;

    private IdleState idle;
    private PatrolState patrol;
    private TraceState trace;
    private AttackState attack;

    private CharacterController cc;
    private Animator anim;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        idle = new IdleState();
        patrol = new PatrolState();
        trace = new TraceState(cc, anim, prefab);
        attack = new AttackState();

        currentState = idle;

    }

    private void Update()
    {
        currentState?.StateUpdate(this);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetState(idle);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetState(patrol);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetState(trace);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SetState(attack);
        }

    }


    public void SetState(IState newState)
    {
        if (currentState != newState)
        {
            currentState?.StateExit(this);
                       
            currentState = newState;

            currentState?.StateEnter(this);

        }
    }

}