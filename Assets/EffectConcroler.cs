using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EffectConcroler : MonoBehaviour
{
    public float lifetime;//多长时间消失

    public float vanishSpeed;//淡化效果


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color -= new UnityEngine.Color(0,0,0,vanishSpeed);//得到color的信息，调节alpha使淡化

        Destroy(gameObject,lifetime);
    }
}
