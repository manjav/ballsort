using UnityEngine;

public class Player : PlayerPrefs
{
    private int _lastLevel;
    public int lastLevel
    {
        get
        {
            if (_lastLevel > 0)
                return _lastLevel;
            if (HasKey("lastLevel"))
                _lastLevel = GetInt("lastLevel");
            else
                lastLevel = 1;
            return _lastLevel;
        }
        set
        {
            if (_lastLevel == value)
                return;
            _lastLevel = value;
            SetInt("lastLevel", _lastLevel);
            Save();
        }
    }
}
