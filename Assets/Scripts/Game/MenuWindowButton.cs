using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindowButton : MonoBehaviour
{
    [SerializeField] private bool isOpenMenu;
    [SerializeField] private GameObject window;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        window.SetActive(isOpenMenu);
    }
}
