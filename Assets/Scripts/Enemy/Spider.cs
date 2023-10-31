using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health 
    {
        get
        {
            return health;
        } 
        set => throw new System.NotImplementedException(); 
    }

    protected override void Init()
    {
        base.Init();
    }

    void IDamageable.Damage()
    {
        throw new System.NotImplementedException();
    }
}
