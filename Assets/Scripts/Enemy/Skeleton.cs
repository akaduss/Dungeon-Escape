using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health 
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }



    protected override void Init()
    {
        base.Init();

    }

    void IDamageable.Damage()
    {
        Health = health - 1;
    }
}
