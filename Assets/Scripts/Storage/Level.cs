using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  // level unlock status
  public bool level2 = false;
  public bool level3 = false;
  public bool level4 = false;

  // level setter
  public void unlockAndSaveLevel(bool l2, bool l3, bool l4)
  {
    level2 = l2;
    level3 = l3;
    level4 = l4;

    LevelManager.SaveLevel(this);
  }

  public void LoadUnlockedLevels()
  {
    LevelData data = LevelManager.LoadLevel();

    if(data != null)
    {
      level2 = data.level2;
      level3 = data.level3;
      level4 = data.level4;
    }
    else
    {
      Debug.Log("Save file not found! This shouldn't be a problem if you're running the game for the first time or haven't unlocked any levels yet.");
    }
  }
}
