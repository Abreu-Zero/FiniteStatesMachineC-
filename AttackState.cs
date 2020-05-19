using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    float rotSpeed = 2.5f;
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
            Vector3 dir = player.position - npc.transform.position;
            float angle = Vector3.Angle(dir, npc.transform.forward);
            dir.y = 0;
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
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
