using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueState : State
{
    public PursueState(GameObject npc, NavMeshAgent agent, Transform player)
        : base(npc, agent, player)
    {
        stateName = STATE.PURSUE;
        agent.speed = 4;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        
        agent.SetDestination(player.position);
        if (agent.hasPath)
        {
            if (!PlayerInView())
            {
                nextState = new PatrolState(npc, agent, player);
                phase = EVENT.EXIT;
            }

            if (PlayerInRange())
            {
                nextState = new AttackState(npc, agent, player);
                phase = EVENT.EXIT;

            }
        }
        
    }

    public override void Exit()
    {
        base.Exit();

    }
}
