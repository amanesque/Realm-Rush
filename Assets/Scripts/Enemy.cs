using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int goldReward, goldPenalty;

    private Bank bank;

    private void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if(bank == null)
        {
            return;
        }

        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if(bank == null)
        {
            return;
        }

        bank.Withdraw(goldPenalty);
    }
}
