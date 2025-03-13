using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PokersManager : MonoBehaviour
{
    public GameObject[] pokers;
    public PokerControl[] pokerControl;
    private static readonly string[] pokersIDs = { "A", "A", "B", "B", "C", "C", "D", "D" };
    void InitPokers()
    {
        pokers = new GameObject[8];
        pokerControl = new PokerControl[8];
        GameObject temp=null;
        for(int i = 0; i < 8; i++)
        {
            if (i % 2 == 0) temp = GameObject.Find(pokersIDs[i]);
            pokers[i] = GameObject.Instantiate(temp);
            if (i % 2 == 1) Destroy(temp);
            //pokers[i].SetActive(true);
            pokerControl[i] = pokers[i].GetComponent<PokerControl>();
 
            pokerControl[i].cardName = pokers[i].name;
            pokerControl[i].matchIndex =pokerControl[i].oriIndex = i;
            pokerControl[i].UpdatePosition(i,false);
            //pokers[i]
        }

    } 
    //////////////////

    public string matchPokers;
    public int matchl, matchr;//from 0 to 3         unmatched from 4 to 7
    public int matchingIndex; 
    public void InitMatch()
    {

        if (matchl >= 0)
        {
            foreach (PokerControl temp in pokerControl) if(matchl<= temp.matchIndex&&temp.matchIndex<=matchr) temp.Init();
        }
        matchl = matchr = -3;
        matchingIndex = -3;
        matchPokers = "";
    }
    public string GetMatchPokers()
    {
        return matchPokers;
    }

    //////////////////
    void Start()
    {
        //        InitPokerManager();
        InitMatch();
        InitPokers();

    }
    //////////////////
    public int ClickType()//0 illegal     1 add left       2 add right    3 delete
    {
        if (matchingIndex >= 4) return 0;
        if (matchl == -3)
        {
            matchl = matchingIndex+1;
            matchr = matchingIndex;
            return 1;
        }
        if (matchingIndex == matchl - 1) return 1;
        if (matchingIndex == matchr + 1) return 2;
        if (matchl <= matchingIndex && matchingIndex <= matchr) return 3;
        return 0;
    }
    public void AddMatch(int arrayIndex,bool isLeft)
    {
        string added = $"{pokers[arrayIndex].name[0]}";
        if (matchPokers == null)
        {
            Debug.Log("Not give Pokers name");
        }
        if (isLeft)
        {
            
            matchl--;
            matchPokers = added + matchPokers;
        }
        else
        {
            matchr++;
            matchPokers = matchPokers+ added;
        }
    }
    public void DelMatchPokers()
    {
        int[] newPosition=new int[8];
        bool[] needAnime = new bool[8];
        foreach (PokerControl Pcthis in pokerControl)
        {
            int now = Pcthis.matchIndex;
            if (Pcthis.matchIndex > matchr)
            {
                newPosition[now] = now - (matchr - matchl+1);
                needAnime[now] = true;
            }
            else if (matchl <= Pcthis.matchIndex && Pcthis.matchIndex <= matchr)
            {
                newPosition[now] = now + (7 - matchr);
                needAnime[now] = false;
            }
            else 
                newPosition[now] = now;


        }
        foreach (PokerControl Pcthis in pokerControl)
        {
            int now = Pcthis.matchIndex;
            Pcthis.UpdatePosition(newPosition[now], needAnime[now]);
        }
        InitMatch();
    }
    //////////////////
    private void Update()
    {
        //for (int i = 0; i < pokers.Length; i++)
        //{
        //    pokers[i].UpdatePosition();
        //}

    }
}