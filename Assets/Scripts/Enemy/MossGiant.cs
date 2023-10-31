using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            Health = value;
        }
    }

    protected override void Init()
    {
        base.Init();
        Health = health;
    }


    void IDamageable.Damage()
    {
        Health--;
    }
}
