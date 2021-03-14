using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ゲームの基礎になる部分
public class MainGame : MonoBehaviour
{
    public enum SeenType
    {
        FirstTime,
        Move,
        TouchRelease,
        DeleteProcess,
        ReproductionProcess,
        SearchProcess
    }

    public SeenType Seen = SeenType.FirstTime;
    private HexMap HexMapCS;

    private int ComboCount;
    // Start is called before the first frame update
    void Start()
    {
        HexMapCS = FindObjectOfType<HexMap>();
        StartCoroutine(MainLoop());
    }

    IEnumerator MainLoop()
    {
        while (true)
        {
            //1フレーム待つ
            yield return null;

            switch (Seen)
            {
                case SeenType.FirstTime:

                    HexMapCS.MSCheck();
                    //消すところがないか
                    if (HexMapCS.Setflag())
                    {
                        HexMapCS.ScoreInit();
                        Debug.Log("Moveにいく");
                        //タッチできるように
                        Seen = SeenType.Move;
                    }
                    else
                    {
                        //消して再度再生
                        yield return StartCoroutine("wait");
                    }


                    break;
                case SeenType.Move:
                    HexMapCS.MoveMagicStone();
                    //動かし終わったらTouchReleaseに移動
                    if (HexMapCS.GetGoodRelease())
                    {
                        HexMapCS.SetGoodRelease(false);
                        Debug.Log("TouchReleaseにいく");
                        //タッチできるように
                        Seen = SeenType.TouchRelease;
                    }
                    HexMapCS.ComboCounter = 0;
                    break;
                case SeenType.TouchRelease:

                    //全マスをCheck
                    HexMapCS.MSCheck();
                    Seen = SeenType.DeleteProcess;
                    Debug.Log("DeleteProcessにいく");

                    break;
                case SeenType.DeleteProcess:
                    if (HexMapCS.Setflag())
                    {
                        Debug.Log("Moveにいく");
                        //タッチできるように
                        Seen = SeenType.Move;
                    }
                    else
                    {
                        HexMapCS.ComboCounter++;
                        yield return StartCoroutine("wait");

                        Debug.Log("TouchReleaseにいく");
                        Seen = SeenType.TouchRelease;
                        Debug.Log(ComboCount);
                    }

                    break;
                case SeenType.ReproductionProcess:
                    break;
                case SeenType.SearchProcess:
                    break;
                default:
                    Debug.Log("デフォルトにいった");
                    break;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator wait()
    {

        //消す処理
        HexMapCS.MSDelete();
        Debug.Log("消す処理");
        //停止
        yield return new WaitForSeconds(0.3f);
        //消して再度再生
        //HexMapCS.DownMS();
        HexMapCS.MSReincarnation();
        Debug.Log("再度再生");
        //停止
        yield return new WaitForSeconds(0.5f);
        //消せるところがあるかCheck
        HexMapCS.MSReCheck();
        Debug.Log("再検索");
    }
}