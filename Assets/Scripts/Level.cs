using System.Collections.Generic;
using System;
using System.Xml.Serialization;

[Serializable]
public class Level
{
    [XmlAttribute("index")] public int index;
    [XmlAttribute("prize")] public int prize;
    [XmlArrayItem("glass")] public List<List<Ball.Type>> glasses;

    public int glassCount
    {
        get
        {
            return glasses == null ? 0 : glasses.Count;
        }
    }
}