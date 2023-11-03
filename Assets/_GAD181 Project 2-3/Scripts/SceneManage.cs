using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void LoadScene(string scene)
    {
      SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
      Application.Quit();
    }
}
