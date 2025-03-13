using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TaskControl : MonoBehaviour
{
    public Vector3[,,] taskPosition;
    TasksManager TMthis;
    UIManager UIthis;
    moveAnime mvthis;
    AllData Althis;
    //AllData.InputTaskGroup data=new AllData.InputTaskGroup();
    public string TaskGroup;
    string text;
    //index decide its index in array       while      rank decide position
    public int date, index, rank, ddl;Vector3 toPosition, myPosition,ori;
    public bool alwaysPulled = false;
    public bool ispulled=false,inlist=false;
    public GameObject[] sons;
    double[] PokerXX = { -2.387308, -0.7829583, 0.8039972, 2.412692 };//scale Vector3(0.95652169,0.949999988,0.180000007)  Y -4.71707344
    public void InitTask(int mydate,int inputIndex,string inputTaskGroup,int inputDdl)
    {
        Althis = GameObject.Find("scripts").GetComponent<AllData>();
        UIthis = GameObject.Find("UIManager").GetComponent<UIManager>();
        mvthis = this.GetComponent<moveAnime>();
        TMthis = GameObject.Find("scripts").GetComponent<TasksManager>();
        taskPosition = new Vector3[21, 201, 2];
        date = mydate;
        index=rank = inputIndex;
        ddl = inputDdl;
        TaskGroup = inputTaskGroup;
        sons = new GameObject[4];
        for(int i = 0; i < TaskGroup.Length; i++)
        {
            sons[i] = GameObject.Instantiate(GameObject.Find($"{TaskGroup[i]}newcard"));
            sons[i].transform.parent=this.GetComponent<Transform>();
            sons[i].transform.localPosition = new Vector3((float)PokerXX[i], -4.71707344f, 0);
            sons[i].transform.localScale = new Vector3(0.95652169f, 0.949999988f, 0.180000007f);
            //sons[i].transform.GetComponent<SpriteRenderer>().sortingOrder = rank;
        }
        text = Althis.mp[TaskGroup];
        alwaysPulled = ispulled = false;
        updatePosion(false);
    }
    double[] PokerX = { -4.00, -2.00, 0.00, 2.00, 4.00, 4.36, 4.70, 5.1 };
    double[] PokerY = { -3.5, -3.5, -3.5, -3.5, -3.5, -3.5, -3.5, -3.5 };
    public Vector3 hoverOffset = new Vector3(0, -0.5f, 0); // 物体下移的距离
    Vector3 originalPosition;
    Vector3 getPosition()
    {
        int temp = rank;
        if (temp >= 7) temp = 7;
        if (math.max(0, -TMthis.lastDate + date) == 0)
            return new Vector3((float)PokerX[temp], -(float)(PokerY[temp] + 0.5f), 0);
        else return new Vector3(200, 0, 0);
    }
    public void updatePosion(bool needAnime)
    {
        mvthis.MoveTo(getPosition(), needAnime);
        originalPosition = getPosition();
        this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = (8-rank)*2;
        for (int i = 0; i < TaskGroup.Length; i++)
        {
            sons[i].transform.GetComponent<SpriteRenderer>().sortingOrder = (8 - rank) * 2+1;
        }
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
        //if (rank >= 4) return;
        //PullUp();
    }

    void OnMouseExit()
    {
        //if (alwaysPulled) return;
        //PullDown();
    }
    void OnMouseDown()
    {
        if (UIthis.IsPause == true) return;
        if (rank >= 4) return;
        if (TMthis.matchingCard!=this)
        {
            TMthis.matchingCard.alwaysPulled = false;
            TMthis.matchingCard.PullDown();
            TMthis.matchingCard = this;  
            PullUp();
            alwaysPulled = true;

        }
        else if (TMthis.matchingCard == this)
        {
            alwaysPulled = false;
            PullDown();
            TMthis.matchingCard = TMthis.first;
        }
    }
    ///
    /// 
    ///

    //public void PullUp()
    //{
    //    if (alwaysPulled) return;
    //    //if (mvthis.IsMoving() == true) return;
    //    isPulled = false;
    //    updatePosion(true);
    //}
    //public void PullDown()
    //{
    //    //if (alwaysPulled) return;
    //    //if (mvthis.IsMoving() == true) return;
    //    isPulled = true;
    //    updatePosion(true);
    //}
    //private void OnMouseDown()
    //{

    //    if (inlist == false) return;
    //    Debug.Log(this.TaskGroup);
    //    if (TMthis.matchingCard ==  this)
    //    {         
    //        TMthis.matchingCard.ChangePullStatus();
    //        TMthis.InitMatch();

    //    }
    //    else if(TMthis.matchingCard!=TMthis.first) 
    //    {
    //        TMthis.matchingCard.ChangePullStatus();
    //        TMthis.InitMatch();
    //        //alwaysPulled = true;
    //        alwaysPulled = true;
    //        PullDown();
    //        TMthis.matchingCard = this;
    //        //TMthis.matchingCard.ChangePullStatus();
    //    }
    //        //matchingIndex = index;
    //    //TMthis.dialogControl[0].ChangePullStatus(matchingIndex);

    //}
    //private void OnMouseOver()
    //{
    //    if (inlist == false) return;
    //    PullUp();
    //    //UIthis.Intro.SetActive(true);
    //    //UIthis.Intro.(text);
    //    //UIthis.Intro.transform = Input.mousePosition;
    //}
    //private void OnMouseExit()
    //{
    //    if (inlist == false) return;
    //    PullDown();
    //    //UIthis.Intro.SetActive(false);
    //}
}
