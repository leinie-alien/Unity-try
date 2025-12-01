using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    private SpriteRenderer SR;//命名一个引用

    public Sprite defaltImage;
    public Sprite pressedImage;//两张图片

    public KeyCode keyToPress;//说明有一个按键

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();//说明要引用这个里面的数据
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) { SR.sprite = pressedImage; }//按键按下改图片

        if(Input.GetKeyUp(keyToPress)) {SR.sprite = defaltImage; }//按键弹起改回图片
    }
}
