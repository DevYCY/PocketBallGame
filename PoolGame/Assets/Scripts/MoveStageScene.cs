using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveStageScene : MonoBehaviour {
    public Button Stage1Btn;
    public Button Stage2Btn;
    public Button Stage3Btn;
    public Button Stage4Btn;

    public void Stage01()
    {
        SceneManager.LoadScene("Hallway");
        Time.timeScale = 1.0f;
    }
    public void Stage02()
    {
        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1.0f;
    }
    public void Stage03()
    {
        SceneManager.LoadScene("Stage3");
        Time.timeScale = 1.0f;
    }
    public void Stage04()
    {
        SceneManager.LoadScene("Stage4");
        Time.timeScale = 1.0f;
    }
}