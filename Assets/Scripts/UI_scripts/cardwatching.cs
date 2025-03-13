using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cardwatching : MonoBehaviour
{
    TasksManager Tmthis;
    // Start is called before the first frame update
    double[] CardX = { -1.67 , 0.44 , 2.53 , 4.58 };
    double[] CardY = { 2.85 , -0.16 , -3.13 };
    Vector3 rec= new Vector3(200, 0, 0);
    public void close()
    {
        for (int addDay = 1; addDay <= 3; addDay++)
        {
            int nowDay = addDay +Tmthis. lastDate;
            if (nowDay >= Tmthis.GetcntDays()) break;
            int j = 0;
            foreach (TaskControl eachthis in Tmthis.dialogControl[nowDay].taskControlThis)
            {
                moveAnime mvthis = eachthis.GetComponent<moveAnime>();
                mvthis.MoveTo(rec, false);
                j++;
                eachthis.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (eachthis.sons[i] == null) break;
                    eachthis.sons[i].transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
            }



            //for (int i = 0; i <Tmthis. dialogControl[nowDay].taskControlThis.Length; i++)
            //ftthis.tasks[addDay - 1, i] = dialogControl[nowDay].taskControlThis[nowDay].gameObject;
            //ftthis.tasks_num[addDay - 1] = dialogControl[nowDay].taskControlThis.Length;
        }  
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {

        Tmthis = GameObject.Find("scripts").GetComponent<TasksManager>();
        //void GetNextTasks()
        //{ 
        //    future_tasks ftthis=GameObject.Find("Panel_future_tasks").GetComponent<future_tasks>();
        int lastDate = Tmthis.lastDate;
        for (int addDay = 1; addDay <= 3; addDay++)
        {
            int nowDay = addDay + lastDate;
            if (nowDay >=Tmthis. GetcntDays()) break;
            int j = 0;
            foreach (TaskControl eachthis in Tmthis.dialogControl[nowDay].taskControlThis)
            {
                moveAnime mvthis = eachthis.GetComponent<moveAnime>();
                mvthis.MoveTo(new Vector3((float)CardX[j], (float)CardY[addDay - 1], 0f), false);
                j++;
                eachthis.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = 200;
                for (int i = 0; i < 4; i++)
                {
                    if (eachthis.sons[i] == null) break;
                    eachthis.sons[i].transform.GetComponent<SpriteRenderer>().sortingOrder = 201;
                }
            }
            //for (int i = 0; i <Tmthis. dialogControl[nowDay].taskControlThis.Length; i++)
                //ftthis.tasks[addDay - 1, i] = dialogControl[nowDay].taskControlThis[nowDay].gameObject;
            //ftthis.tasks_num[addDay - 1] = dialogControl[nowDay].taskControlThis.Length;
        }
        //}
    }
    private void OnMouseExit()
    {
        close();
    }
    private void OnMouseDown()
    {
        close();
    }
}
