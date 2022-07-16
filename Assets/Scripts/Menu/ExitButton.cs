using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private ExitMenu exitMenu;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenExitMenu);
    }

    private void OpenExitMenu()
    {
        exitMenu.OpenMenu();
    }
}
