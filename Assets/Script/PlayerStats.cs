using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _startMoney;
    [SerializeField] private int _startLives;
    public static int Lives;
    public static int Money;
    

    private void Start()
    {
        Money = _startMoney;
        Lives = _startLives;
    }


}
