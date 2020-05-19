using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private int currentIndex = -1;

    public PatrolState(GameObject npc, NavMeshAgent agent, Transform player)
        : base(npc, agent, player)
    {
        stateName = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (!PlayerInView())
        {
            if (agent.remainingDistance <= 1)
            {
                if (currentIndex >= GameEnv.Singleton.Checkpoints.Count - 1)
                {
                    currentIndex = 0;
                    Debug.Log("reseting wp to wp " + currentIndex);
                }
                else
                {
                    currentIndex++;
                    Debug.Log("SetDestination to wp " + currentIndex);
                    agent.SetDestination(GameEnv.Singleton.Checkpoints[currentIndex].transform.position);
                } 
            }
            
        }
        
        
        if(PlayerInView())
        {
            nextState = new PursueState(npc, agent, player);
            phase = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();

    }
}
