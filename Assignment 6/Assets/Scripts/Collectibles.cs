using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    public int coinTally;

    protected virtual void Awake()
    {
        coinTally = 0;
    }

    public abstract void addCoin(int amount);
    public abstract void OnTriggerEnter(Collider other);
    public abstract void destroyCoin();


    
}
