using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    public AttackState(GameObject npc, NavMeshAgent agent, Transform player)
        : base(npc, agent, player)
    {
        stateName = STATE.ATTACK;
        agent.speed = 4;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {

        if (PlayerInRange())
        {
            npc.GetComponent<Shoot>().Fire();
        }
        else
        {
            nextState = new IdleState(npc, agent, player);
            phase = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        base.Exit();

    }
}
