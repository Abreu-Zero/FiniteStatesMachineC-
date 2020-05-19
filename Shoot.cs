using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool canShoot = true;
    public void Fire()
    {
        if (canShoot)
        {
            Debug.Log("NPC is Attacking the Player");
            canShoot = false;
            Invoke("Reload", 2.5f);
        }
     
    }

    void Reload()
    {
        Debug.Log("NPC is Reloading");
        canShoot = true;
    }


}
