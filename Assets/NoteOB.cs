using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class NoteOB : MonoBehaviour
{

    public bool canBePress;

    public KeyCode keyTopress;//哪一个按键被按

    public float perfectAdjust, hitAdjust;

    public GameObject missEffect, hitEffect, perfectEffect;//后来做特效

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyTopress))//按下的按键是否是设定的按键
        {
            if (canBePress)//是否可以被按压
            {
                gameObject.SetActive(false);//留了一个端口，先不启动以看效果

                if(transform.position.y >= -1.7f - perfectAdjust && transform.position.y <= -1.7f + perfectAdjust)
                {
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                else
                {
                    Debug.Log(100);
                    GameManager.instance.NormalHit();//运行Gamemanager里的这部分
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//碰到trigger
    {
        if(other.tag == "Stray")//碰到的物体标签为
        {
            canBePress = true;//可以被点击
        }
    }

    private void OnTriggerExit2D(Collider2D other)//离开trigger
    {
        if(other.tag == "Stray" && gameObject.activeSelf)
        {

            canBePress = false;//避免误输入

            GameManager.instance.NoteMiss();

            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
        
    }
}
