using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderBoard
{
    public static int MembersCount { get; private set; } = 7;

    public static int LastLeader
    {
        get
        {
            return PlayerPrefs.GetInt("LastLeader", -1);
        }
        private set
        {
            PlayerPrefs.SetInt("LastLeader", value);
            PlayerPrefs.Save();
        }
    }

    public static void CleanLeader()
    {
        LastLeader = -1;
    }

    public static bool UpdateLeader(int points)
    {
        var leaders = GetLeaders();
        if (leaders.Length == MembersCount)
        {
            if (points < leaders[leaders.Length - 1] && leaders.Length < MembersCount)
            {
                return false;
            }
        }
        if (leaders.Length < MembersCount)
        {
            AddElementToEnd(ref leaders);
        }

        int targetIndex = 0;
        for (int i = 0; i < leaders.Length; i++)
        {
            if (points > leaders[i])
            {
                targetIndex = i;
                break;
            }
        }
        int temp = leaders[targetIndex];
        leaders[targetIndex] = points;
        for (int i = targetIndex + 1; i < leaders.Length; i++)
        {
            var t = leaders[i];
            leaders[i] = temp;
            temp = t;
        }
        LastLeader = targetIndex;

        SetLeaders(leaders);
        return true;
    }

    private static void AddElementToEnd(ref int[] leaders)
    {
        var newArray = new int[leaders.Length + 1];
        for (int i = 0; i < leaders.Length; i++)
        {
            newArray[i] = leaders[i];
        }
        newArray[newArray.Length - 1] = 0;
        leaders = newArray;
    }

    private static void SetLeaders(int[] leaders)
    {
        var leadersText = JsonConvert.SerializeObject(leaders);
        PlayerPrefs.SetString("Leaders", leadersText);
        PlayerPrefs.Save();
    }

    public static int[] GetLeaders()
    {
        var leadersText = PlayerPrefs.GetString("Leaders");
        if (leadersText.Length == 0)
            return new int[0];
        return JsonConvert.DeserializeObject<int[]>(leadersText);
    }
}
