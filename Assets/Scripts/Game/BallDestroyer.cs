using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    public static BallDestroyer instance = null;

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    public void DestroyBalls(List<Ball> balls, BallsComboType comboType)
    {
        foreach(var ball in balls)
        {
            BallsContainer.instance.CleanBall(ball.position);
        }
    }
}
