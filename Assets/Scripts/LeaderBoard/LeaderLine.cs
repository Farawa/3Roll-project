using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderLine : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI tmp;

    public void SetLight()
    {
        image.color = Color.green;
    }

    public void SetValue(int value)
    {
        tmp.text = value.ToString();
    }
}
