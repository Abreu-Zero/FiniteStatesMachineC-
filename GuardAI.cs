using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform player;
    State currentState;

    // Start is called before the first frame updates
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentState = new IdleState(this.gameObject, agent, player);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
