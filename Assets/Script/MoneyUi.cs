using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUi : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;

   
    void Update()
    {
        MoneyText.text = "Money = " + PlayerStats.Money.ToString();
    }
}
