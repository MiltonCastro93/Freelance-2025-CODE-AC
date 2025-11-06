using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Enemy : Entity {
    [SerializeField] protected float timeMax = 2;
    protected float coolDown;

    public override void GenerateDamage(int D) {
        life -= D;
    }

}
