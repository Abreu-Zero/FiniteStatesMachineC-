using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public IdleState(GameObject npc, NavMeshAgent agent, Transform player)
        :base (npc, agent, player) 
    {
        stateName = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if(Random.Range(0,5) >= 4)
        {
            nextState = new PatrolState(npc, agent, player);
            phase = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();

    }
}
