using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public Player player;
    [HideInInspector] public Level currentLevel;
    public List<TextAsset> levels;
    public bool gameEnd;

    public void LoadLevel()
    {
        if (player == null)
            player = new Player();
        // load xml player.lastLevel
        if (currentLevel == null || currentLevel.index != player.lastLevel)
            currentLevel = LoadLevel(player.lastLevel);
    }

    public Level LoadLevel(int index)
    {
        var serializer = new XmlSerializer(typeof(Level));
        using (var reader = new System.IO.StringReader(levels[index].text))
        {
            return serializer.Deserialize(reader) as Level;
        }
    }

    /* public void SaveLevel()
    {
        var level = new Level();
        level.index = 0;
        level.glasses = new List<List<Type>>();
        level.glasses.Add(new List<Type>() { Type.blue, Type.blue, Type.red, Type.red });
        level.glasses.Add(new List<Type>() { Type.red, Type.red, Type.blue, Type.blue });
        level.glasses.Add(new List<Type>());


        var serializer = new XmlSerializer(typeof(Level));
        print(Application.dataPath + "\\test.xml");
        var stream = new FileStream(Application.dataPath + "\\test.xml", FileMode.Create);
        serializer.Serialize(stream, level);
        stream.Close();
    } */

}
