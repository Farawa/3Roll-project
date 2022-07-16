using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitChoice : MonoBehaviour
{
    [SerializeField] private ExitMenu exitMenu;
    [SerializeField] private bool isCloseApp;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (isCloseApp)
        {
            Application.Quit();
        }
        else
        {
            exitMenu.CloseMenu();
        }
    }
}
