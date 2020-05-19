using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameEnv
{

    private static GameEnv instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    public static GameEnv Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnv();
                instance.checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Guard WP"));
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
            }
            return instance;
        }
    }

}
