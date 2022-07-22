
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestLeader : MonoBehaviour
{
    public TMP_InputField tmp;
    public Button btn;

    private void Start()
    {
        btn.onClick.AddListener(click);
    }

    private void click()
    {
        var value = int.Parse(tmp.text);
        LeaderBoard.UpdateLeader(value);
        SceneOpener.OpenScene(SceneType.leaderBoard);
    }
}
