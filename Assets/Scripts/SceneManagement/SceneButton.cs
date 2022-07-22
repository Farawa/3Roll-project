using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private Button button;
    private void Start()
    {
        if (!button)
            button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneOpener.OpenScene(sceneType);
    }
}
