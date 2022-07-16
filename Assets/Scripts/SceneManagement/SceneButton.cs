using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneOpener.OpenScene(sceneType);
    }
}
