using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCoin : Collectibles
{
    protected override void Awake()
    {
        base.Awake();
        coinTally = 500;
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
