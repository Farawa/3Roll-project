using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsContainer : MonoBehaviour
{
    public static BallsContainer instance = null;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private RectTransform field;
    private List<Ball> balls = new List<Ball>();

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    private void Start()
    {
        (transform as RectTransform).sizeDelta = field.sizeDelta;
        transform.position = field.position;
    }

    public Ball GetBall()
    {
        var randomColor = (BallColor)Random.Range(0, 5);
        foreach (var ball in balls)
        {
            if (ball.position == -Vector2Int.one)
            {
                ball.Color = randomColor;
                return ball;
            }
        }
        var t = Instantiate(ballPrefab, transform);
        var newBall = t.GetComponent<Ball>();
        balls.Add(newBall);
        newBall.Color = randomColor;
        return newBall;
    }

    public Ball GetBall(Vector2Int position)
    {
        foreach (var ball in balls)
        {
            if (ball.position == position)
            {
                return ball;
            }
        }
        return null;
    }

    public void CleanBall(Vector2Int position)
    {
        var ball = GetBall(position);
        if (!ball) throw new System.Exception("попытка очистить шар, возможно функция вызывается дважды");

        ball.position = -Vector2Int.one;
        ball.transform.position = Vector2.one * 99999;

    }
}
