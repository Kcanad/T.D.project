using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update()
    {
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        Debug.Log("End Game");
    }
}
