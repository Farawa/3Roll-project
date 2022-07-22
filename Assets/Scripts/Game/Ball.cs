using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float moveTime = 0.5f;
    public Vector2Int position = -Vector2Int.one;
    public bool isMoving;
    private BallColor color = BallColor.white;
    public BallColor Color
    {
        get { return color; }
        set
        {
            color = value;
            SetColor(value);
        }
    }

    public async void Move()
    {
        if (!isMoving)
            await System.Threading.Tasks.Task.Delay(20);
        var bottomPos = position + new Vector2Int(0, 1);
        var bottomBall = BallsContainer.instance.GetBall(bottomPos);
        bool isCanMove = true;
        if (bottomBall)
        {
            if (!bottomBall.isMoving)
            {
                isCanMove = false;
            }
        }
        if (!Field.instance.IsCellExist(bottomPos))
        {
            isCanMove = false;
        }
        if (isCanMove)
        {
            isMoving = true;
            var bottomCellPosition = Field.instance.GetCellWorldPosition(bottomPos);
            transform.DOMove(bottomCellPosition, moveTime).OnComplete(() => Move()).SetEase(Ease.Linear);
            var topPos = position - new Vector2Int(0, 1);
            var topBall = BallsContainer.instance.GetBall(topPos);
            position = bottomPos;
            if (topBall)
            {
                if (!topBall.isMoving)
                {
                    //await System.Threading.Tasks.Task.Delay(50);
                    topBall.Move();
                }
            }
            else if (topPos.y == -1)
            {
                //await System.Threading.Tasks.Task.Delay(50);
                BallsContainer.instance.SpawnNewBall(topPos);
            }
        }
        else
        {
            isMoving = false;
            Combinations.SearchCombinations(this);
        }
    }

    public void UpdateWorldPosition()
    {
        transform.position = Field.instance.GetCellWorldPosition(position);
    }

    private void SetColor(BallColor color)
    {
        if (color == BallColor.blue)
            image.color = UnityEngine.Color.blue;
        else if (color == BallColor.green)
            image.color = UnityEngine.Color.green;
        else if (color == BallColor.red)
            image.color = UnityEngine.Color.red;
        else if (color == BallColor.white)
            image.color = UnityEngine.Color.white;
        else if (color == BallColor.yellow)
            image.color = UnityEngine.Color.yellow;
    }
}
