using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Combinations
{
    public static void SearchCombinations(Ball ball)
    {
        //знаю, что можно было бы здесь получить весь список шаров и уже по ссылке отправлять в функции, но решил, что так пока сойдет TODO
        var combo = BallsComboType.marth3;
        List<Ball> list = GetMarth5(ball);
        if (list.Count > 0)
            combo = BallsComboType.marth5;

        var list4 = GetMarth5(ball);
        foreach (var t in list4)
        {
            if (!list.Contains(t))
                list.Add(t);
        }
        if (combo == BallsComboType.marth3 && list.Count > 0)
            combo = BallsComboType.marth4;

        var list3 = GetMarth3(ball);
        foreach (var t in list3)
        {
            if (!list.Contains(t))
                list.Add(t);
        }
        if (list.Count == 0) return;
        BallDestroyer.instance.DestroyBalls(list, combo);
    }

    /*
                    0-4
                    0-3
                    0-2 
                    0-1 
    -40 -30 -20 -10 00 10 20 30 40
                    01 
                    02 
                    03 
                    04 
    */
    public static List<Ball> GetMarth3(Ball ball)
    {
        List<Ball> balls = new List<Ball>();
        var position = ball.position;

        var left1Ball = BallsContainer.instance.GetBall(GetPosition(position, -1, 0));
        var left2Ball = BallsContainer.instance.GetBall(GetPosition(position, -2, 0));

        var right1Ball = BallsContainer.instance.GetBall(GetPosition(position, 1, 0));
        var right2Ball = BallsContainer.instance.GetBall(GetPosition(position, 2, 0));

        var top1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -1));
        var top2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -2));

        var bot1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 1));
        var bot2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 2));

        var targetColor = ball.Color;
        //-20 -10 00
        TryAddBalls(new Ball[] { left2Ball, left1Ball }, ref balls, targetColor);
        //-10 00 10
        TryAddBalls(new Ball[] { left1Ball, right1Ball }, ref balls, targetColor);
        //00 10 20
        TryAddBalls(new Ball[] { right1Ball, right2Ball }, ref balls, targetColor);
        //0-2 0-1 00
        TryAddBalls(new Ball[] { top2Ball, top1Ball }, ref balls, targetColor);
        //0-1 00 01
        TryAddBalls(new Ball[] { top1Ball, bot1Ball }, ref balls, targetColor);
        //00 01 02
        TryAddBalls(new Ball[] { bot1Ball, bot2Ball }, ref balls, targetColor);

        if (balls.Count > 0)
            balls.Add(ball);

        return balls;
    }

    public static List<Ball> GetMarth4(Ball ball)
    {
        List<Ball> balls = new List<Ball>();
        var position = ball.position;

        var left1Ball = BallsContainer.instance.GetBall(GetPosition(position, -1, 0));
        var left2Ball = BallsContainer.instance.GetBall(GetPosition(position, -2, 0));
        var left3Ball = BallsContainer.instance.GetBall(GetPosition(position, -3, 0));

        var right1Ball = BallsContainer.instance.GetBall(GetPosition(position, 1, 0));
        var right2Ball = BallsContainer.instance.GetBall(GetPosition(position, 2, 0));
        var right3Ball = BallsContainer.instance.GetBall(GetPosition(position, 3, 0));

        var top1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -1));
        var top2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -2));
        var top3Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -3));

        var bot1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 1));
        var bot2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 2));
        var bot3Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 3));

        var targetColor = ball.Color;
        //-30 -20 -10 00
        TryAddBalls(new Ball[] { left3Ball, left2Ball, left1Ball, right1Ball }, ref balls, targetColor);
        //-20 -10 00 10
        TryAddBalls(new Ball[] { left2Ball, left1Ball, right1Ball }, ref balls, targetColor);
        //-10 00 10 20
        TryAddBalls(new Ball[] { left1Ball, right1Ball, right2Ball }, ref balls, targetColor);
        //00 10 20 30
        TryAddBalls(new Ball[] { right1Ball, right2Ball, right3Ball }, ref balls, targetColor);

        //0-3 0-2 0-1 00
        TryAddBalls(new Ball[] { top3Ball, top2Ball, top1Ball }, ref balls, targetColor);
        //0-2 0-1 00 01
        TryAddBalls(new Ball[] { top2Ball, top1Ball, bot1Ball }, ref balls, targetColor);
        //0-1 00 01 02
        TryAddBalls(new Ball[] { top1Ball, bot1Ball, bot2Ball }, ref balls, targetColor);
        //00 01 02 03
        TryAddBalls(new Ball[] { bot1Ball, bot2Ball, bot3Ball }, ref balls, targetColor);

        if (balls.Count > 0)
            balls.Add(ball);

        return balls;
    }

    public static List<Ball> GetMarth5(Ball ball)
    {
        List<Ball> balls = new List<Ball>();
        var position = ball.position;

        var left1Ball = BallsContainer.instance.GetBall(GetPosition(position, -1, 0));
        var left2Ball = BallsContainer.instance.GetBall(GetPosition(position, -2, 0));
        var left3Ball = BallsContainer.instance.GetBall(GetPosition(position, -3, 0));
        var left4Ball = BallsContainer.instance.GetBall(GetPosition(position, -4, 0));

        var right1Ball = BallsContainer.instance.GetBall(GetPosition(position, 1, 0));
        var right2Ball = BallsContainer.instance.GetBall(GetPosition(position, 2, 0));
        var right3Ball = BallsContainer.instance.GetBall(GetPosition(position, 3, 0));
        var right4Ball = BallsContainer.instance.GetBall(GetPosition(position, 4, 0));

        var top1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -1));
        var top2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -2));
        var top3Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -3));
        var top4Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, -4));

        var bot1Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 1));
        var bot2Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 2));
        var bot3Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 3));
        var bot4Ball = BallsContainer.instance.GetBall(GetPosition(position, 0, 4));

        var targetColor = ball.Color;
        //-40 -30 -20 -10 00
        TryAddBalls(new Ball[] { left4Ball, left3Ball, left2Ball, left1Ball }, ref balls, targetColor);
        //-30 -20 -10 00 10
        TryAddBalls(new Ball[] { left3Ball, left2Ball, left1Ball, right1Ball }, ref balls, targetColor);
        //-20-10 00 10 20
        TryAddBalls(new Ball[] { left2Ball, left1Ball, right1Ball, right2Ball }, ref balls, targetColor);
        //-10 00 10 20 30
        TryAddBalls(new Ball[] { left1Ball, right1Ball, right2Ball, right3Ball }, ref balls, targetColor);
        //00 10 20 30 40
        TryAddBalls(new Ball[] { right1Ball, right2Ball, right3Ball, right4Ball }, ref balls, targetColor);

        //0-4 0-3 0-2 0-1 00
        TryAddBalls(new Ball[] { top4Ball, top3Ball, top2Ball, top1Ball }, ref balls, targetColor);
        //0-3 0-2 0-1 00 01
        TryAddBalls(new Ball[] { top3Ball, top2Ball, top1Ball, bot1Ball }, ref balls, targetColor);
        //0-2 0-1 00 01 02
        TryAddBalls(new Ball[] { top2Ball, top1Ball, bot1Ball, bot2Ball }, ref balls, targetColor);
        //0-1 00 01 02 03
        TryAddBalls(new Ball[] { top1Ball, bot1Ball, bot2Ball, bot3Ball }, ref balls, targetColor);
        //00 01 02 03 04
        TryAddBalls(new Ball[] { bot1Ball, bot2Ball, bot3Ball, bot4Ball }, ref balls, targetColor);


        if (balls.Count > 0)
            balls.Add(ball);

        return balls;
    }

    private static bool TryAddBalls(Ball[] balls, ref List<Ball> list, BallColor targetColor)
    {
        foreach (var ball in balls)
        {
            if (!ball)
                return false;
        }
        foreach (var ball in balls)
        {
            if (ball.Color != targetColor || ball.isMoving)
                return false;
        }
        foreach (var ball in balls)
        {
            list.Add(ball);
        }
        return true;
    }

    public static Vector2Int GetPosition(Vector2Int startPosition, int x, int y)
    {
        Vector2Int pos = startPosition;
        pos.x += x;
        pos.y += y;
        return pos;
    }
}
