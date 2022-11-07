using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : Collectibles
{
    protected override void Awake()
    {
        base.Awake();
        coinTally = 0;
    }

    public override void OnTriggerEnter(Collider other)
    {
        addCoin(coinTally);
        destroyCoin();
    }

    public override void addCoin(int coinTally)
    {
        Debug.Log("Found a Purple Coin!");
    }

    public override void destroyCoin()
    {
        Destroy(gameObject);
    }
}
