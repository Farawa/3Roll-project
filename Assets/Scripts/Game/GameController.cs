using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    [SerializeField] private PointsPerCombo[] pointsPerCombos;

    [SerializeField] private int startMovesCount = 3;
    [SerializeField] private TextDisplay pointsDisplay;
    [SerializeField] private TextDisplay movesDisplay;
    [SerializeField] private GameObject sadWindow;
    private int points = 0;
    private int moveRemain = 0;
    private Coroutine endGameCoroutine;

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    private void Start()
    {
        moveRemain = startMovesCount;
        sadWindow.SetActive(false);
        UpdateDisplays();
    }

    internal void DestroyBall(Ball ball)
    {
        if (moveRemain > 0)
        {
            BallDestroyer.instance.DestroyBall(ball);
            moveRemain--;
            if (moveRemain == 0)
            {
                if (endGameCoroutine != null)
                    StopCoroutine(endGameCoroutine);
                endGameCoroutine = StartCoroutine(EndGameCoroutine());
            }
        }
        UpdateDisplays();
    }

    private IEnumerator EndGameCoroutine()
    {
        while (true)
        {
            bool isBallsMooving = BallsContainer.instance.IsAnyBallMoving();
            if (isBallsMooving)
                yield return new WaitForSeconds(0.1f);
            else
            {
                if (moveRemain > 0)
                    break;
                else
                {
                    EndGame();
                    break;
                }
            }
        }
    }

    private void EndGame()
    {
        if(LeaderBoard.UpdateLeader(points))
        {
            SceneOpener.OpenScene(SceneType.leaderBoard);
        }
        else
        {
            sadWindow.SetActive(true);
        }
    }

    public void UpdateDisplays()
    {
        pointsDisplay.UpdateDisplay(points);
        movesDisplay.UpdateDisplay(moveRemain);
    }

    public void AddPoints(BallsComboType comboType,int destroyedBallsCount)
    {
        bool isFounded = false;
        foreach (var t in pointsPerCombos)
        {
            if (t.combo == comboType)
            {
                moveRemain += t.points;
                isFounded = true;
                break;
            }
        }
        if (!isFounded)
            throw new System.Exception("комбо не найдено, заполните массив");
        points += destroyedBallsCount;
        UpdateDisplays();
    }
}
