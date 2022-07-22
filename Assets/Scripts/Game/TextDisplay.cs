using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string addictiveText;

    public void UpdateDisplay(int value)
    {
        text.text = addictiveText + " " + value;
    }
}
