using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void LoadScene(string scene)
    {
      if(scene == "Story-2" && PlayedIntro.intro == false)
      {
        SceneManager.LoadScene("MainTest");
      } else {
        if(scene == "Story-2")
        {
          PlayedIntro.intro = false;
        }
        SceneManager.LoadScene(scene);
      }
    }

    public void Exit()
    {
      Application.Quit();
    }
}
