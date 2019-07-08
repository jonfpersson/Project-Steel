using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    [SerializeField] private Text uiText;

    public void UpdateUI(string playerName)
    {
        uiText.text = playerName;
    }
}
