using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MSSprite : MonoBehaviour
{

    public enum StoneColor
    {
        Red = 0,
        Yellow = 1,
        Blew = 2,
        Green = 3,
        Purple = 4
    }
    //元画像への参照
    public Sprite[] MSSperite;
    //現在の色
    public StoneColor nowStoneColor;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //色を変更する関数
    public void ChangeSprite(int index)
    {
        nowStoneColor = (StoneColor)index;
        GetComponent<SpriteRenderer>().sprite = MSSperite[index];
    }



    public void MovAnime(Vector3 invec ,Vector3 outvec)
    {
        transform.position = invec;
        transform.DOMove(outvec, 0.5f);
    }

    public void inScaleAnime()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(0.9f, 0.5f).SetEase(Ease.OutBounce);
    }
    public void ScaleSet(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
    public void outScaleAnime()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.DOScale(0.0f, 0.3f).SetEase(Ease.OutBounce);
    }

    public void ChengeColor(float a)
    {
        GetComponent<SpriteRenderer>().color = new Color(a, a, a);
    }

}
