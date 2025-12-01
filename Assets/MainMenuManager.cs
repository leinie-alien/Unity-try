using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public AudioSource audioSource;



    public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // 这里是你游戏主场景的名字
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene"); // 设置场景
    }

    public void GoToGameScene(string sceneName)//而不是在前面public string targetScene(不方便传参（但是也可以用
    {
        SceneManager.LoadScene(sceneName); // 目标场景的名字
    }

    public void QuitGame()
    {
        Application.Quit(); // 在打包后才会退出游戏，编辑器中无效
        Debug.Log("EXIT");
    }

    public void PlayClick()
    {
        audioSource.Play(); // 或 PlayOneShot(clip)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

