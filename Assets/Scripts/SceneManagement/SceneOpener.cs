using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneOpener
{
    public static void OpenScene(SceneType type)
    {
        SceneManager.LoadSceneAsync((int)type);
    }
}
