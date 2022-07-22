using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardWindow : MonoBehaviour
{
    [SerializeField] private LeaderLine[] leaderLines;

    private void Start()
    {
        if (leaderLines.Length != LeaderBoard.MembersCount)
            throw new System.Exception("в скрипте LeaderBoard не верно указано количество участников таблицы, измените значение");
        var array = LeaderBoard.GetLeaders();
        for(int i = 0; i < array.Length; i++)
        {
            leaderLines[i].SetValue(array[i]);
            if (i == LeaderBoard.LastLeader)
                leaderLines[i].SetLight();
        }
    }
}
