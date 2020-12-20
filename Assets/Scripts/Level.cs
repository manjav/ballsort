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

    public int glassCount
    {
        get
        {
            return glasses == null ? 0 : glasses.Count;
        }
    }
}