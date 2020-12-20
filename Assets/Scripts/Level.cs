using System.Collections.Generic;
using static Ball;
using System;

[Serializable]
public class Level 
{
    public int index;
    public int prize;
    public int glassCount;
    public List<List<BallType>> glasses;

    void Start()
    {
        index = 1;
        glassCount = 3;
        glasses = new List<List<BallType>>();
        glasses[0] = new List<BallType>() { BallType.blue, BallType.blue, BallType.red, BallType.red };
        glasses[1] = new List<BallType>() { BallType.red, BallType.red, BallType.blue, BallType.blue };
        //Ball.BallType tempValue = (Ball.BallType)glasses[0][0];
        //glasses[0][0] = tempValue;
    }
}