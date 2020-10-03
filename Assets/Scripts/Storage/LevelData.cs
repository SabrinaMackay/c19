using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    // level unlock status
    public bool level2;
    public bool level3;
    public bool level4;

    public LevelData(Level level)
    {
      level2 = level.level2;
      level3 = level.level3;
      level4 = level.level4;
    }

}
