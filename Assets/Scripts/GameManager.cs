using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Level currentLevel;
    public Player player;
    public bool gameEnd;

    void Start()
    {
        player = new Player();
    }

    public void ShowLevel()
    {
        // load xml player.lastLevel

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
}
