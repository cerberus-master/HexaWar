using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int[,]MonsterStatus = new int[,]
    //最初は各モンスターのID
        {
    //HP,攻撃力,守備力,重さ,速さ,属性
            {10,10,1,2,0},
            {20,15,10,5,2},
            {30,20,20,10,3},
            {40,25,30,30,4},
            {50,30,40,30,5}
        };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
