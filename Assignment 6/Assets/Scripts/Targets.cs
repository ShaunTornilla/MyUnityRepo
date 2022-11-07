using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targets: MonoBehaviour
{
    public float speed;
    public float health; 

    protected virtual void Awake()
    {
        speed = 1f;
        health = 100;

    }

    public abstract void TakeDamage(int amount);
    public abstract void Die();

}
