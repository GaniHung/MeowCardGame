using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreInTotal : MonoBehaviour
{
    float Xmid=0f;
    float Y=-3.5f;
    float deltaX = 1.2f;
    void newStar(int starnum)
    {
        GameObject star = GameObject.Find("Star");
        for(int i = 1; i <= starnum; i++)
        {

            GameObject te = GameObject.Instantiate(star);
            te.transform.localPosition=new Vector3(Xmid+(i-(1+starnum)/2.0f)*deltaX,Y,0);
        }
    }
    private void Awake()
    {
        Xmid = 0f;
        Y = -3.1f;
        deltaX = 1.2f;
        Record temp = GameObject.Find("Record").GetComponent<Record>();
        int score = temp.totalScore;
        int startNum=1;
        if (score <= 30)
        {
            startNum = 1;
        }
        else if (score <=60)
        {
            startNum = 2;
        }
        else
        {
            startNum = 3;
        }
        newStar(startNum);
    }
}
