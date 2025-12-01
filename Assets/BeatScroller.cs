using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;//曲谱速度

    public bool hasStart = false;//还没开始

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;//游戏60帧，把节奏速度bpm换算
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart)
        {
            //if (Input.anyKey)
            //{
            //    hasStart = true;//在GameManager里控制就好
            //}
        }
        else
        {
            transform.position += new Vector3(0f, -beatTempo * Time.deltaTime, 0f);//曲谱下移，曲谱速度*时间间隔
        }
    }
}
