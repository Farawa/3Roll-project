using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardFiller : MonoBehaviour
{
    private void Start()
    {
        if (LeaderBoard.GetLeaders().Length == 0)
        {
            LeaderBoard.UpdateLeader(250);
            LeaderBoard.UpdateLeader(220);
            LeaderBoard.UpdateLeader(190);
            LeaderBoard.UpdateLeader(150);
            LeaderBoard.UpdateLeader(100);
            LeaderBoard.UpdateLeader(75);
            LeaderBoard.UpdateLeader(50);
        }
    }
}
