using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PokerControl : MonoBehaviour
{
    UIManager Uithis;
    moveAnime mvthis;
    double[] PokerX = {-4.00,-2.00,0.00,2.00,4.00, 4.36, 4.70, 5.1 };
    double[] PokerY = {-3.5,-3.5,-3.5,-3.5,-3.5,-3.3,-3.1,-2.9 };
    //double[] PokerZ = { 0};
    TasksManager Tmthis;
    PokersManager Pmthis;
    public int oriIndex, matchIndex;
    public string cardName;
    bool ispulled=false;
    //bool alwaysPulled = false;
    public Vector3 hoverOffset = new Vector3(0, 0.5f, 0); // 物体上移的距离
    private Vector3 originalPosition; // 原始位置
    Vector3 getPosition()
    {
        return new Vector3((float)PokerX[matchIndex],(float)(PokerY[matchIndex]+1f), 0);
    }
    public void Init()
    {
        PullDown();
    }
    void Awake()
    {
        mvthis = this.GetComponent<moveAnime>();
        Pmthis = GameObject.Find("scripts").GetComponent<PokersManager>();
        Uithis = GameObject.Find("UIManager").GetComponent<UIManager>();
        Tmthis = GameObject.Find("scripts").GetComponent<TasksManager>();
        cardName = this.gameObject.name;//test
    }
    public void PullUp()
    {
        //if (mvthis.IsMoving()==true) return;
        if (ispulled == false)
            mvthis.MoveTo(originalPosition + hoverOffset, true);
        ispulled = true;
    }
    public void PullDown()
    {
        //if (mvthis.IsMoving() == true) return;
        if (ispulled == true)
            mvthis.MoveTo(originalPosition , true);
        ispulled = false;
    }
    void OnMouseOver()
    {
        //if (alwaysPulled) return;
        //if (matchIndex >= 4) return;
        //PullUp();
    }

    void OnMouseExit()
    {
        //if (alwaysPulled) return;
        //PullDown();
    }
    public bool needLeftShift=false;
    public void UpdatePosition(int newIndex,bool needAnime)
    {      
        matchIndex = newIndex;
        mvthis.MoveTo(getPosition(),needAnime);
        originalPosition = getPosition();
        this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = 8-matchIndex;
    }
    void PlayAnime()
    {
        GameObject playAnimeOne = GameObject.Instantiate(this.gameObject);
        playAnimeOne.transform.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Destroy(playAnimeOne);
    }
    public void DeletePoker()
    {
        PlayAnime();
        //UpdatePosition(7, false);
        //update matchindex and position
    }
    int  ClickType()//0 illegal     1 add left       2 add right    3 delete
    {
        Pmthis.matchingIndex = matchIndex;
        return Pmthis.ClickType();
    }
    void OnMouseDown()
    {
        if (Uithis.IsPause == true) return;
        if (ClickType() == 1) Pmthis.AddMatch(oriIndex, true);
        else if (ClickType() == 2) Pmthis.AddMatch(oriIndex,false);
        else if (ClickType() == 0 || ClickType() == 3) { Pmthis.InitMatch(); }

        if (Pmthis.matchl <= matchIndex && matchIndex <= Pmthis.matchr) 
        {
            //alwaysPulled = true;
            PullUp();
        }
        else
        {
            //alwaysPulled = false;
            PullDown();
        }
    }
        
}