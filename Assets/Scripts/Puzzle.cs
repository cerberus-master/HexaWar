using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    //配列の大きさを定義。
    private int width = 16;
    private int height = 14;

    public int[] ColeScore = new int[6];


    //魔石の色の配置
    public int[,] MAPData = new int[16, 14];
    //消えるID
    public int[,] DeleteData = new int[16, 14];
    //消えるID
    public int[,] DownData = new int[16, 14];

    public int[,] OutFlag = new int[,]
    {
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,0,0,0,0,0,0,0,0,0,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1,1,1}
    };

    //Puzzleデバッグ用盤面
    public int[,] ColorFlag = new int[,]
    {
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,2,2,2,2,2,2,2,2,1,1},
       { 1,1,3,3,3,3,3,3,3,3,1,1},
       { 1,1,4,4,4,4,4,4,4,4,1,1},
       { 1,1,0,0,0,0,0,0,0,0,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,2,2,2,2,2,2,2,2,1,1},
       { 1,1,3,3,3,3,3,3,3,3,1,1},
       { 1,1,4,4,4,4,4,4,4,4,1,1},
       { 1,1,0,0,0,0,0,0,0,0,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,2,2,2,2,2,2,2,2,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1},
       { 1,1,1,1,1,1,1,1,1,1,1,1}
    };

    //各方角に検索、２マスだけ
    public int[,] DD = new int[,]
      {
        {1,1,1,2,0,1,1,2 },//右上奇数,偶数
        {1,0,2,0,1,0,2,0 },//右奇数,偶数
        {1,-1,1,-2,0,-1,1,-2 },//右下奇数,偶数
        {0,-1,-1,-2,-1,-1,-1,-2 },//左下奇数,偶数
        {-1,0,-2,0,-1,0,-2,0 },//左奇数,偶数
        {0,1,-1,2,-1,1,-1,2 }//左上奇数,奇数
      };


    // Start is called before the first frame update
    void Start()
    {
        InitScore();
        InitDown();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public int GetScore(int c)
    {
        return ColeScore[c];
    }
    public void SetScore(int c,int s)
    {
        ColeScore[c] += s;
    }


    public void InitScore()
    {
        for (int i = 0; i < 6; i++)
        {
            ColeScore[i] = 0;
        }
    }

    public void InitDown()
    {

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                DownData[i, j] = 0;
            }
        }
    }
    public int GetDoenData(int i,int j)
    {
        return DownData[i, j];
    }

    public void SetDoenData(int i, int j,int set)
    {
        DownData[i, j] = set;
    }

    //落とせるところがあるか
    public bool CheckDoenData()
    {
        bool Check;
        Check = false;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (DownData[i, j] == 1)
                {
                    Check = true;
                }

            }
        }
        return Check;
    }

    //DeletDataを反映
    public void FlagGetDoenData()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (DeleteData[i, j] == 1)
                {
                    DownData[i, j] = 1;
                }
            }
        }
    }


    public int GetColorFlag(int i,int j)
    {
        return ColorFlag[i,j];
    }

    public int GetOutFlag(int x,int y)
    {
        return OutFlag[x, y];
    }


    public void SetMapDate(int i, int j, int data)
    {
        MAPData[i, j] = data;
    }

    public int GetMapDate(int i, int j)
    {
        return MAPData[i, j];
    }

    public void SetDeleteDate(int i, int j, int data)
    {
        DeleteData[i, j] = data;
    }
    public int GetDeleteDate(int i, int j)
    {
        return DeleteData[i, j];
    }


    //同じ色判定
    public void MatchMS(int IDx, int IDy)
    {
        for (int i = 0; i < 3; i++)
        {
            //同じ計算が多いので短略
            int a = (IDx + DD[i, 0]);
            int aa = (IDy + DD[i, 1]);
            int b = (IDx + DD[i, 2]);
            int bb = (IDy + DD[i, 3]);
            int c = (IDx + DD[i, 4]);
            int cc = (IDy + DD[i, 5]);
            int d = (IDx + DD[i, 6]);
            int dd = (IDy + DD[i, 7]);

            int x;

            if (i >= 3)
            {
                x = (i - 3);
            }
            else
            {
                x = (i + 3);
            }

            int ax = (IDx + DD[x, 0]);
            int aax = (IDy + DD[x, 1]);
            int bx = (IDx + DD[x, 2]);
            int bbx = (IDy + DD[x, 3]);
            int cx = (IDx + DD[x, 4]);
            int ccx = (IDy + DD[x, 5]);
            int dx = (IDx + DD[x, 6]);
            int ddx = (IDy + DD[x, 7]);


            //奇数偶数判定
            if (IDy % 2 == 1)
            {
                //同じ色かどうか判定　１個め
                if (MAPData[IDx, IDy] == MAPData[a, aa]&& OutFlag[a,aa]==0)
                {
                    //同じ色かどうか判定２個め
                    if (MAPData[IDx, IDy] == MAPData[b, bb] && OutFlag[b, bb] == 0)
                    {
                        //同じ色かどうか判定３個め
                        if (MAPData[IDx, IDy] == MAPData[ax, aax] && OutFlag[ax, aax] == 0)
                        {
                            //同じ色かどうか判定４個目
                            if (MAPData[IDx, IDy] == MAPData[bx, bbx] && OutFlag[bx, bbx] == 0)
                            {
                                ColeScore[MAPData[IDx, IDy]] += 15;
                                //元データ
                                DeleteData[IDx, IDy] = 1;
                                //一個前削除設定
                                DeleteData[a, aa] = 1;
                                //削除設定
                                DeleteData[b, bb] = 1;
                                //一個前削除設定
                                DeleteData[ax, aax] = 1;
                                //削除設定
                                DeleteData[bx, bbx] = 1;
                            }
                            else//３個め
                            {
                                ColeScore[MAPData[IDx, IDy]] += 8;
                                //元データ
                                DeleteData[IDx, IDy] = 1;
                                //一個前削除設定
                                DeleteData[a, aa] = 1;
                                //削除設定
                                DeleteData[b, bb] = 1;
                                //一個前削除設定
                                DeleteData[ax, aax] = 1;
                            }
                        }
                    }//同じ色かどうか判定２個め
                    else  if (MAPData[IDx, IDy] == MAPData[ax, aax] && OutFlag[ax, aax] == 0)
                    {
                        //同じ色かどうか判定３個め
                        if (MAPData[IDx, IDy] == MAPData[bx, bbx] && OutFlag[bx, bbx] == 0)
                        {
                            ColeScore[MAPData[IDx, IDy]] += 8;
                            //元データ
                            DeleteData[IDx, IDy] = 1;
                            //一個前削除設定
                            DeleteData[a, aa] = 1;
                            //一個前削除設定
                            DeleteData[ax, aax] = 1;
                            //削除設定
                            DeleteData[bx, bbx] = 1;
                        }
                        else//２個め
                        {
                            ColeScore[MAPData[IDx, IDy]] += 3;
                            //元データ
                            DeleteData[IDx, IDy] = 1;
                            //一個前削除設定
                            DeleteData[a, aa] = 1;
                            //一個前削除設定
                            DeleteData[ax, aax] = 1;
                        }
                    }
                }//一個目
                else if (MAPData[IDx, IDy] == MAPData[ax, aax] && OutFlag[ax, aax] == 0)
                {
                    //同じ色かどうか判定2個め
                    if (MAPData[IDx, IDy] == MAPData[bx, bbx] && OutFlag[bx, bbx] == 0)
                    {
                        ColeScore[MAPData[IDx, IDy]] += 3;
                        //元データ
                        DeleteData[IDx, IDy] = 1;
                        //一個前削除設定
                        DeleteData[ax, aax] = 1;
                        //削除設定
                        DeleteData[bx, bbx] = 1;
                    }
                }

            }//奇数偶数
            else if (IDy % 2 == 0)
            {
                //同じ色かどうか判定１個め
                if (MAPData[IDx, IDy] == MAPData[c, cc] && OutFlag[c,cc] == 0)
                {
                    //同じ色かどうか判定２個め
                    if (MAPData[IDx, IDy] == MAPData[d, dd] && OutFlag[d, dd] == 0)
                    {
                        //同じ色かどうか判定３個め
                        if (MAPData[IDx, IDy] == MAPData[cx, ccx] && OutFlag[cx, ccx] == 0)
                        {
                            //同じ色かどうか判定４個目
                            if (MAPData[IDx, IDy] == MAPData[dx, ddx] && OutFlag[dx, ddx] == 0)
                            {
                                ColeScore[MAPData[IDx, IDy]] += 15;
                                //元データ
                                DeleteData[IDx, IDy] = 1;
                                //一個前削除設定
                                DeleteData[c, cc] = 1;
                                //削除設定
                                DeleteData[d, dd] = 1;
                                //一個前削除設定
                                DeleteData[cx, ccx] = 1;
                                //削除設定
                                DeleteData[dx, ddx] = 1;
                            }
                            else//３個め
                            {

                                ColeScore[MAPData[IDx, IDy]] += 8;
                                //元データ
                                DeleteData[IDx, IDy] = 1;
                                //一個前削除設定
                                DeleteData[c, cc] = 1;
                                //削除設定
                                DeleteData[d, dd] = 1;
                                //一個前削除設定
                                DeleteData[cx, ccx] = 1;

                            }
                        }
                    }//３個め
                    else  if (MAPData[IDx, IDy] == MAPData[cx, ccx] && OutFlag[cx, ccx] == 0)
                    {
                        //同じ色かどうか判定４個目
                        if (MAPData[IDx, IDy] == MAPData[dx, ddx] && OutFlag[dx, ddx] == 0)
                        {
                            ColeScore[MAPData[IDx, IDy]] += 8;
                            //元データ
                            DeleteData[IDx, IDy] = 1;
                            //一個前削除設定
                            DeleteData[c, cc] = 1;
                            //一個前削除設定
                            DeleteData[cx, ccx] = 1;
                            //削除設定
                            DeleteData[dx, ddx] = 1;
                        }//３個め
                        else
                        {
                            ColeScore[MAPData[IDx, IDy]] += 3;
                            //元データ
                            DeleteData[IDx, IDy] = 1;
                            //一個前削除設定
                            DeleteData[c, cc] = 1;
                            //一個前削除設定
                            DeleteData[cx, ccx] = 1;

                        }
                    }
                }//1個め
                else if (MAPData[IDx, IDy] == MAPData[cx, ccx] && OutFlag[cx, ccx] == 0)
                {
                    //同じ色かどうか判定2個目
                    if (MAPData[IDx, IDy] == MAPData[dx, ddx] && OutFlag[dx, ddx] == 0)
                    {
                        ColeScore[MAPData[IDx, IDy]] += 3;
                        //元データ
                        DeleteData[IDx, IDy] = 1;
                        //一個前削除設定
                        DeleteData[cx, ccx] = 1;
                        //削除設定
                        DeleteData[dx, ddx] = 1;
                    }
                }
            }
        }
    }
}


