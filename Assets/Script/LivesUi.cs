using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUi : MonoBehaviour
{
    public TextMeshProUGUI LivesText;

        void Update()
    {
        LivesText.text = "Live's = " + PlayerStats.Lives.ToString();
    }
}
