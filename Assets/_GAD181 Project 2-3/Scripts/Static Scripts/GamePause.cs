using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePause
{
  public static bool paused;

  public static void Pause()
  {
    paused = true;
    Time.timeScale = 0;
  }

  public static void UnPause()
  {
    paused = false;
    Time.timeScale = 1;
  }
}
