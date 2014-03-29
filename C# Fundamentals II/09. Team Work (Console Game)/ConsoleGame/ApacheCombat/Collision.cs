using System;
using System.Collections.Generic;
using System.Numerics;


class Collision
{
    //Helicopter Collision
    public static void HelicopterObstacleColision(List<Obstacle> obstacles, Helicopter helicopter, ref int lives,ref BigInteger score, int bombs)
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if ((obstacles[i].StartX == helicopter.EndX && !(obstacles[i].EndY < helicopter.StartY || obstacles[i].StartY > helicopter.EndY))
            || ((obstacles[i].EndY == helicopter.StartY || obstacles[i].StartY == helicopter.EndY) && !(obstacles[i].EndX < helicopter.StartX || obstacles[i].StartX > helicopter.EndX))
            || (obstacles[i].EndX == helicopter.StartX && !(obstacles[i].EndY < helicopter.StartY || obstacles[i].StartY > helicopter.EndY)))
            {
                Window.DeleteObstacle(obstacles[i]);
                obstacles.RemoveAt(i);
                i--;
                lives--;
                score -= 10;
                if (lives == 0)
                {
                    EndGameScreen.FinishGame(score);
                }
                else
                {
                    Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                    Window.DeleteAllObstacles(obstacles);              
                    obstacles.Clear();
                }
            }
        }
    }

    public static void ObstacleHelicopterColision(List<Obstacle> obstacles, Obstacle obstacle, Helicopter helicopter, ref bool collision, ref int lives, ref BigInteger score, int bombs)
    {
        if ((obstacle.StartX == helicopter.EndX && !(obstacle.EndY < helicopter.StartY || obstacle.StartY > helicopter.EndY))
        || ((obstacle.EndY == helicopter.StartY || obstacle.StartY == helicopter.EndY) && !(obstacle.EndX < helicopter.StartX || obstacle.StartX > helicopter.EndX))
        || (obstacle.EndX == helicopter.StartX && !(obstacle.EndY < helicopter.StartY || obstacle.StartY > helicopter.EndY)))
        {
            obstacle.StartX++;
            Window.DeleteObstacle(obstacle);
            lives--;
            score -= 10;
            collision = true;
            if (lives == 0)
            {
                EndGameScreen.FinishGame(score);
            }
            else
            {
                Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                Window.DeleteAllObstacles(obstacles);
                obstacles.Clear();
            }
        }
    }


    //Obstacle Shot Collision
    public static void HandleShotObstacleCollisions(List<Obstacle> obstacles, Shot shot, ref bool hit, int lives, ref  BigInteger score, int bombs)
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if ((shot.EndX == obstacles[i].StartX && (shot.EndY >= obstacles[i].StartY && shot.EndY <= obstacles[i].EndY)))
            {
                Window.DeleteShot(shot);
                Window.DeleteObstacle(obstacles[i]);
                obstacles.RemoveAt(i);
                i--;
                hit = true;
                score += 10;
                Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                break;
            }
        }
    }

    public static void HandleObstacleCollisionsWithShots(List<Obstacle> obstacles, Obstacle obstacle, List<Shot> shots, ref bool hit, int lives, ref BigInteger score, int bombs)
    {
        for (int i = 0; i < shots.Count; i++)
        {
            if ((shots[i].EndX == obstacle.StartX && (shots[i].EndY >= obstacle.StartY && shots[i].EndY <= obstacle.EndY)))
            {
                Window.DeleteShot(shots[i]);
                shots.RemoveAt(i);                
                obstacles.Remove(obstacle);
                obstacle.StartX++;
                Window.DeleteObstacle(obstacle);
                hit = true;
                score += 10;
                Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                i--;
                break;
            }
        }
    }

    public static void NuclearBombExplosion(List<Obstacle> obstacles, ref BigInteger score)
    {
        score += (obstacles.Count * 10);
        obstacles.RemoveRange(0, obstacles.Count);
    }
}
