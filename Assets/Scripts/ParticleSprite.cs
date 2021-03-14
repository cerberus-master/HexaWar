using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSprite : MonoBehaviour
{

    ParticleSystem m_ParticleSystem;
    private ParticleSystem.Particle[] m_Particles;
    float m_TotalTime = 0;
    public float m_Speed = 1;
    Vector3 tmp;
    Color MColor;
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得
        m_ParticleSystem = GetComponent<ParticleSystem>();
        MColor = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ParticleStart()
    {
        //パーティクルを再生（追加）
        GetComponent<ParticleSystem>().Play();
    }


    public void ChengeColor(int a)
    {

        ParticleSystem.MainModule par = GetComponent<ParticleSystem>().main;
        switch (a)
        {
            case 0:

                par.startColor =  Color.red;
                break;
            case 1:
                par.startColor = Color.yellow;
                break;
            case 2:
                par.startColor = Color.blue;
                break;
            case 3:
                par.startColor = Color.green;
                break;
            case 4:
                par.startColor = Color.magenta;
                break;
            default:
                break;

        }
    }

}
