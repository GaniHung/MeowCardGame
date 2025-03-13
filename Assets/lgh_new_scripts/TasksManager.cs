using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
public class TasksManager : MonoBehaviour
{

    //public static TasksManager Instance { get; private set; }

    // Start is called before the first frame update
    public int cntTopCard;
    static public GameObject dialog;
    //static public AllData datathis;        
    static AllData.InputTaskGroup data= new AllData.InputTaskGroup() ;//cntTaskGroup[i] the cnt of TaskGroup in i th date  
    public UIManager uithis;
    public AllData Althis;
    PokersManager Pmthis;
    public bool needAnime=false;//cntTaskGroup[i] sum of days
    public TaskControl matchingCard;
    public int lastDate;
    public bool gameover = false;

    public LinkedList<TaskControl> TopTasks = new LinkedList<TaskControl>();
    public TaskControl first;
    public void InitMatch()
    {    
        matchingCard.alwaysPulled = false;
        matchingCard.PullDown();
        matchingCard = first;
    }
    AudioSource temp;
    void Init()
    {

        temp = GameObject.Find("flapcard").GetComponent<AudioSource>();
        Althis = GameObject.Find("scripts").GetComponent<AllData>();
        uithis = GameObject.Find("UIManager").GetComponent<UIManager>();
        Pmthis = GameObject.Find("scripts").GetComponent<PokersManager>();
        dialog = GameObject.Find("TaskCard");
        first = GameObject.Find("temp").GetComponent<TaskControl>();
        first.TaskGroup = "YU";
        lastDate=-2;
        matchingCard= first;
        //matchingCard.TaskGroup = "YU";
       
        data.initInput();
        InitTaskManager();
        Destroy(dialog);
    }
    
    public class TaskList
    {
        public bool come = false;
        public int myDate;
        int leftDate;
 
        GameObject[] taskCard;
        public TaskControl[] taskControlThis;
         public void InitTaskList(int inputMyDate)
        {
            myDate = inputMyDate;
            taskCard = new GameObject[data.cntTaskGroup[myDate]];
            taskControlThis = new TaskControl[data.cntTaskGroup[myDate]];
            //for (int i = 0; i < taskCard.Length; i++) taskControlThis[i].GetComponent<TaskControl>();
            int sum = 0;
            for (int i = 0; i <= myDate; i++)
            {
                sum += data.cntTaskGroup[i];
            }
            sum -= data.cntTaskGroup[myDate];
            for (int j = 0; j < data.cntTaskGroup[myDate]; j++)
            {
                taskCard[j] = GameObject.Instantiate(dialog);
                taskControlThis[j]=taskCard[j].GetComponent<TaskControl>();
                taskControlThis[j].InitTask(myDate, j, data.taskGroup[sum + j], data.ddl[sum+j]);
                //ret[i].AddComponent<colors>();
                //ret[i].AddComponent<number>();
            }
        }

        static public void PlayAnime(GameObject playAnimeOne)
        {
            Destroy(playAnimeOne);
        }
    }        
        public TaskList[] dialogControl;
    public int GetcntDays() 
    {
        return data.cntTaskGroup.Length;
    }
    public int GetcntTask()
    {
        return data.taskGroup.Length;
    }
    int sumSolvedTask = 0;
    void updateDoubleList(bool isNewDay)
        {
        Debug.Log("come");
        Debug.Log(lastDate);
        TaskList diathis = dialogControl[lastDate];
        if (diathis.come==false)
        {
            diathis.come = true;
            
            foreach(TaskControl Tcthis in dialogControl[lastDate].taskControlThis)
            {
                if (Tcthis == null) continue;
                Tcthis.inlist = true;
                TopTasks.AddLast(Tcthis);
                cntTopCard++;
            }
            for(int i=lastDate+1;i< data.cntTaskGroup.Length;i++)
            foreach (TaskControl Tcthis in dialogControl[i].taskControlThis)
            {
                    if (Tcthis == null) continue;
                    Tcthis.updatePosion(!isNewDay);
                }
        }
        int nowcnt = 0;
            foreach (TaskControl Tcthis in TopTasks)
            {
                if (Tcthis == null) continue;
                Tcthis.rank = nowcnt;
                Tcthis.updatePosion(!isNewDay);
                nowcnt++;
            }
        } 
    public LoadData Ldthis;
    private void InitTaskManager()
    {
        dialogControl = new TaskList[data.cntTaskGroup.Length];
        for (int i = 0; i < data.cntTaskGroup.Length; i++)
        {
            dialogControl[i] = new TaskList();
            dialogControl[i].InitTaskList(i);
        }
    }
    //void GetNextTasks()
    //{ 
    //    future_tasks ftthis=GameObject.Find("Panel_future_tasks").GetComponent<future_tasks>();
    //    for(int addDay = 1; addDay <= 3; addDay++)
    //    {
    //        int nowDay = addDay + lastDate;
    //        if (nowDay > GetcntDays()) break;
    //        for(int i = 0; i < dialogControl[nowDay].taskControlThis.Length;i++)
    //            ftthis.tasks[addDay-1,i]= dialogControl[nowDay].taskControlThis[nowDay].gameObject;
    //        ftthis.tasks_num[addDay-1] = dialogControl[nowDay].taskControlThis.Length;
    //    }
        
    //}
    bool MatchTaskPokers()
        {
        string matchPokerGroup=Pmthis.matchPokers;
        string matchTaskGroup = matchingCard.TaskGroup;
        if (matchTaskGroup.Length 
            != matchPokerGroup.Length) return false;
        int n = matchTaskGroup.Length;
        for (int i = 0; i < n; i++)
        {
            if (matchPokerGroup[i] != matchTaskGroup[i] && matchTaskGroup[i] != 'E') return false;
        }
        //consider quanzhan as everyone
        return true;
        }
    void playAnime(GameObject DeletedCard)
    {

    }
    void DeleteTask(TaskControl DeletedCard)
    {
        if (DeletedCard==first) Debug.Log("false");
        TopTasks.Remove(DeletedCard);
        cntTopCard--;
        Destroy(DeletedCard.gameObject);
        Destroy(DeletedCard);
        InitMatch();
        updateDoubleList(false);
    }

    public void SkipPoker()
    {
        if (Pmthis.matchPokers.Length==1 && uithis.Minus_MovePoints(1))
        {
                Pmthis.DelMatchPokers();
                InitMatch();
        }
    }   
    private void Start()
    {
        Init();
    }
    void Enter_NextDay()
    {
        //if (uithis.AnimeDown == true)
        //{
        if (uithis.enterNex == false)
        {
            uithis.enterNex = true;
            uithis.Enter_NextDay();
        }
        //}
    }
    private void Update()
    {
        if (uithis.enterNex == true) return;
        if (uithis.Date >= GetcntDays()) return;
        if (lastDate != uithis.Date)
        {
            lastDate = uithis.Date;
            updateDoubleList(true);
        }
        //updatePicture
        if (MatchTaskPokers())
        {
            if (uithis.Minus_MovePoints(1))
            {
                temp.Play();
                DeleteTask(matchingCard);
                Pmthis.DelMatchPokers();
                InitMatch();
                updateDoubleList(false);
                sumSolvedTask++;
                if (sumSolvedTask == GetcntTask()) uithis.Victory();
            }
            else Enter_NextDay();
        }
        if(uithis.Minus_MovePoints(0)==false) Enter_NextDay();
        else if (cntTopCard==0) Enter_NextDay();
        foreach (PokerControl p in Pmthis.pokerControl)
        {
            if (Pmthis.matchl <= p.matchIndex && p.matchIndex <= Pmthis.matchr) p.PullUp();
            else p.PullDown();
        }
    }
}
