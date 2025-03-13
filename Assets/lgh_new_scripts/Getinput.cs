using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//waiting for change
public class Getinput:MonoBehaviour
{
    public UIManager uithis;
    public AllData dathis;
    // Start is called before the first frame update
    private void Start()
    {
        uithis = GameObject.Find("scriptsList").GetComponent<UIManager>();
        dathis = GameObject.Find("scriptsList").GetComponent<AllData>();
    }
    //Date ReadDate()
    //{
        
    //    string[] taskGroup=dathis.taskGroup;
    //    return allDate;
    //}
    GameObject[] TasksGO = new GameObject[1001];
  void ReadCsTasks(Task[] Tasks)
    {
        //for (int i = 1; i <= 1000; i++)
        //{
        //    TasksGO[i] = GameObject.Instantiate(Resources.Load("TaskA")) as GameObject;
        //    Tasks[i] = TasksGO[i].GetComponent<Task>();
        //}
    }
    void ReadPositionTasks(Vector3[] TaskUpPosion,Vector3[,] TaskDownPosion)
    {
        //for (int i = 1; i <= 1000; i++) TaskUpPosion[i] = UIthis.TaskUpPosion[i];
        //for (int i = 1; i <= 100; i++)
        //    for (int j = 1; j <= 100; j++)
        //        TaskDownPosion[i,j] = UIthis.TaskDownPosion[i][j];
    }
}
