using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Vector2Int position;
    public void OnPointerClick(PointerEventData eventData)
    {
        var ball = BallsContainer.instance.GetBall(position);
        if (ball)
        {
            if (!ball.isMoving)
                GameController.instance.DestroyBall(ball);
        }
    }
}
