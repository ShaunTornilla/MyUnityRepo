using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;



    // Start is called before the first frame update
    protected override void Awake()
    {
        // Gives us the ability to override the default health in Enemy.cs to what we want the Golem to be
        base.Awake();

        health = 120;
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Golem Attacks!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " points of damage!");
    }
}
