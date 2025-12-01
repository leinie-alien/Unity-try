using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Basic Setting")]
    public AudioSource myMusic;//自己的歌儿

    public bool startPlaying;//是否正在播放

    public BeatScroller BS;//谱子 后续调用里面的东西

    public static GameManager instance;

    public bool emergencyStop;

    public float Score;
    public float ScorePerNote = 100;

    public Text scoreText;
    public Text multiplyText;
    public Text PressTips;

    public float multiply;
    public int multiplyTimes;
    public int baseNumber = 1;//基本倍率

    [Header("Level Setting")]
    public float BaseScoreValue;
    public float PerfectScoreValue = 300;

    [Header("Result")]
    public float totalNotes;
    public float normalHits;
    public float perfectHits;
    public float missHits;

    public GameObject resultScreen;
    public Text normalCounter, perfectCounter, missedCounter, percentage, totalCounter;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;//这个GameManager

        resultScreen.SetActive(false);

        multiply = 1;

        totalNotes = FindObjectsOfType<NoteOB>().Length;//让引擎找所有挂载了 NoteOB 脚本的对象，获得个数（长度）
        //（注意是复数Objects，这样才会返回一个 NoteOB[] 数组，.Length 才合法。否则只会返回第一个找到的对象（不是数组）
    }

    // Update is called once per frame
    void Update()
    {

        multiplyText.text = "x " + multiply;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            emergencyStop = !emergencyStop;//控制暂停开始
            if (emergencyStop)
            {
                myMusic.Pause();
                Time.timeScale = 0;//游戏运行速率
            }
            else { Time.timeScale = 1; myMusic.UnPause(); }
        }


        if (!startPlaying)
        {
            if (Input.anyKeyDown)//是否有按键输入
            {
                startPlaying = true;
                BS.hasStart = true;//于是可以把BS里的这里注释掉
                Destroy(PressTips, 0);

                myMusic.Play();//音乐播放
            }
        }
        else
        {
            if (!myMusic.isPlaying && !resultScreen.activeInHierarchy && !emergencyStop)
            {
                resultScreen.SetActive(true);

                normalCounter.text = "" + normalHits;
                perfectCounter.text = "" + perfectHits;
                missedCounter.text = "" + missHits;

                float totalhit = normalHits + perfectHits;
                float Acc = (totalhit / totalNotes) * 100f;

                percentage.text = Acc.ToString("F2") + "%";//小数点后面保留两位F2

                totalCounter.text = "" + Score;
            }
        }
    }

    public void NoteHit() 
    { 
        //Debug.Log("Hit"); //留接口，打中时返回一个log

        //Score += ScorePerNote + multiply;

        multiplyTimes++;

        multiply = baseNumber + multiplyTimes * 0.05f;

        multiply = (float)Math.Round((decimal)multiply, 1);//因为multiply是float

        scoreText.text = "Score:" + Score;//分数的字符加分数数值
    }

    public void NoteMiss()
    {
        Debug.Log("Miss");//留接口，未打中时返回一个log
        multiplyTimes = 0;
        multiply = 1;
        missHits++;
    }

    public void PerfectHit()
    {
        Score += PerfectScoreValue * multiply;
        NoteHit();
        perfectHits++;
    }

    public void NormalHit()
    {
        Score += BaseScoreValue * multiply;
        NoteHit(); 
        normalHits++;
    }
}
