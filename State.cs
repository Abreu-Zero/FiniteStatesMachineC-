using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, DEAD
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE stateName;
    protected EVENT phase;
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected Transform player;
    protected State nextState;

    //GuardsVariables
    float visDist = 10.0f;
    float shootDist = 7.0f;
    float visAngle = 30.0f;

    //Contructor
    public State(GameObject npc, NavMeshAgent agent, Transform player)
    {
        phase = EVENT.ENTER;
        this.npc = npc;
        this.agent = agent;
        this.player = player;
    }

    public virtual void Enter()
    {
        Debug.Log("Switching to "+ stateName + " State");
        phase = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        phase = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        phase = EVENT.EXIT;
    }

    public State Process()
    {
        if (phase == EVENT.ENTER)
            Enter();
        if (phase == EVENT.UPDATE)
            Update();
        if (phase == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    protected bool PlayerInView()
    {
        Vector3 dir = player.position - npc.transform.position;
        float angle = Vector3.Angle(dir, npc.transform.forward);

        if(dir.magnitude < visDist && angle < visAngle)
        {
            return true;
        }

        return false;

    }

    protected bool PlayerInRange()
    {
        Vector3 dir = player.position - npc.transform.position;
        float angle = Vector3.Angle(dir, npc.transform.forward);

        if (dir.magnitude < shootDist && angle < visAngle)
        {
            return true;
        }

        return false;
    }
}

