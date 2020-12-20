using System.Collections.Generic;
using static Ball;
using System;

[Serializable]
public class Level 
{
    public int index;
    public int prize;
     public List<List<Ball.Type>> glasses;

    public int glassCount
    {
        get
        {
            return glasses == null ? 0 : glasses.Count;
        }
    }
}