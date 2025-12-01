using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    // 在这些场景中不要播放音乐
    public string[] scenesToStopMusic;

    private AudioSource audioSource;//注意只能是AudioSource(否则下面的stop函数失效

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded; // 监听场景加载事件
        }
        else
        {
            Destroy(gameObject); // 避免重复
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 如果当前场景名在“禁止播放音乐”的名单中
        foreach (string sceneName in scenesToStopMusic)
        {
            if (scene.name == sceneName)
            {
                audioSource.Pause(); // 或 Stop()
                return;
            }
        }

        // 如果场景允许播放音乐，就恢复播放（如果未播放）
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
