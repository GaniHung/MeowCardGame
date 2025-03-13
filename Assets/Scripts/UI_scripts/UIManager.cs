using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour


{
    public bool enterNex=false;
    //Audio;
    //public Record record;
    public AllData Althis;
    public LoadData loaddata;
    //[SerializeField] bool preparation=false;
    public GameObject animator_fail;
    public GameObject animator_success;
    public static UIManager Instance;
    public int Date_left;
    public int Date = 0;
    public float Score = 0;
    public float Score_Max;
    public int Movepoint_num = 4;

    public bool IsPause;
    private bool IsGameOver;
    public TextMeshProUGUI Internaltext;
    public GameObject Button_Pause;
    public GameObject Button_Restart;
    //public GameObject Button_checktasks;
    public GameObject Button_closechecktasks;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject TransitonPanel_1;
    public GameObject TransitonPanel_2;
    [SerializeField] private GameObject taskspanel;
    public Vector3[,,] taskPosition;//the 3-D array of positions to place task-cards
                                    //public Transform[] card_slot_array;

    public Calendar calendar;
    public MovePoints MovePoints;
    public Introduction Intro;
    //public Introduction In?tro; //The list of introductions for each task-cards;
    public Text Date_;
    public Text Date_left_;
    public Text yourscore;
    public Text endtext;

    AudioSource temp;

    [SerializeField] private GameObject scorecolumn;

    public int test_dly=0;
    public int All;
    private void Awake()
    {
        Instance = this;
        //AudioManager.Instance.playbgm(AudioManager.Instance.gamebgm);
        taskspanel.SetActive(false);
        calendar = GameObject.Find("Calendar").GetComponent<Calendar>();
        //record = GameObject.Find("Record").GetComponent<Record>();
        if (Record.Instance.scenenum == 1)
        {
            All=Date_left = 6-1;
        }
        if (Record.Instance.scenenum == 2)
        {
            All=Date_left = 9-1;

        }
        if (Record.Instance.scenenum == 3)
        {
            All=Date_left = 12-1;

        }

        calendar.SetTexT(Date_left,Date_left);
        //public void SetTexT(int date, int dateleft)
        //{
        //    Date.text = date.ToString();
        //    Date_left.text = dateleft.ToString();
        //}

    }
    public void Start()
    {   
        scorecolumn = GameObject.Find("column");


        Internaltext.gameObject.SetActive(false);
        Button_Restart.SetActive(false);
        Button_Pause.SetActive(true);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        TransitonPanel_1.SetActive(false);
        TransitonPanel_2.SetActive(false);

        Date = 0;
        calendar.SetTexT(1, Date_left);
        //animator_fail = GameObject.Find("F");
        //animator_success = GameObject.Find("S");
        //animator_success.SetActive(false);
        //animator_fail.SetActive(false);
        IsPause = false;
        IsGameOver = false;

        //foreach(var Introduction in Introductions)

        Intro.Settext("unsigned task");
    }
 
    // Start is called before the first frame update
    public void Init()
    {
        //loaddata = GameObject.Find("loaddate");
        //Internaltext = GameObject.Find("Transition Text").GetComponent<TextMeshProUGUI>();
        //Button_Pause = GameObject.Find("Button_Pause");

        temp = GameObject.Find("endday").GetComponent<AudioSource>();
        Althis = GameObject.Find("scripts").GetComponent<AllData>();
        //Internaltext = GameObject.Find(f);
        loaddata.function();
        taskPosition = new Vector3[21, 201, 2];
        taskPosition = loaddata.taskPosition;
        


        //Date_.text = Date.ToString();
        //Date_left_.text = Date_left.ToString();








    }


    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void DeMovepoint(int minus_num = 1)
    {
        if (Movepoint_num >= minus_num)
        {
            MovePoints.MovePointsUpdate(minus_num);
            Movepoint_num -= minus_num;
        }

    }
    
        public void Enter_NextDay()//����л���һ��
    {
        enterNex = true;
        if (!IsPause && !IsGameOver)
        {

            AddScore(Movepoint_num*10);
            if (Date<All)
            {
                temp.Play();
                calendar.GetComponent<Animator>().Play("TurnPage");
                Debug.Log(":::");
                Debug.Log(Date);
                calendar.SetTexT(Date + 2, Date_left);
                Debug.Log(Date);
                TransitonPanel_1.SetActive(true);
                TransitonPanel_1.GetComponent<Animator>().Play("TP_1");

            }
            else
            {
                Fail();
            }
        }
        
    }


        public void QuitGame()
        {
            Application.Quit();
        }

        public void BackToMainMenu()
        {
            
            SceneManager.LoadScene("MainMenu");

        }

        public void Transition_end()
    {
        TransitonPanel_1.SetActive(true);
        TransitonPanel_1.GetComponent<Animator>().Play("TP_1");
    }
    public void Transition_start()
    {
        TransitonPanel_2.SetActive(true);

        TransitonPanel_2.GetComponent<Animator>().Play("TP_2");
    }
    public void RenewUI()
    {
        enterNex = false;
        Date++;
        Internaltext.text = "";
        Internaltext.gameObject.SetActive(true);
        TransitonPanel_2.SetActive(true);

        TransitonPanel_2.GetComponent<Animator>().Play("TP_2");
        calendar.GetComponent<Animator>().Play("New State");


        Movepoint_num = 4;
        MovePoints.Renew_MovePoints();
        //Date_.text = Date.ToString();
        //Date_left_.text = Date_left.ToString();
    }
    public void Pause()
    {
        if (!IsPause)
        {
            GameObject tmp = GameObject.Find("cardwatching");
            if (tmp != null) tmp.GetComponent<cardwatching>().close();
            IsPause = true;
            Button_Pause.SetActive(false);
            Button_Restart.SetActive(true);
            PausePanel.SetActive(true);
            //Date;
        }
        else
        {
            IsPause = false;
            Button_Pause.SetActive(true);
            Button_Restart.SetActive(false);
            PausePanel.SetActive(false);

        }
        
    }
    public void Restart()
    {
        if (IsPause)
        {
            IsPause = false;
            Button_Pause.SetActive(true);
            Button_Restart.SetActive(false);
            PausePanel.SetActive(false);
        }
    }
  
    public bool Minus_MovePoints(int minus_num)//
    {
        if (Movepoint_num == 0) return false;
        if (minus_num <= Movepoint_num)
        {
            MovePoints.MovePointsUpdate(minus_num);
            Movepoint_num -= minus_num;
            return true;

        }
        else return false;
    }
    public void AddScore(int add_scores)//
    {
        Debug.Log(Score);
        Score += add_scores;
        if(Score > 100) Score =100;
        Record.Instance.totalScore =(int)Score;
        scorecolumn.GetComponent<Scorecolumn1>().Scale(Score);
        
    }
    public void SetIntroduction(string str)//Ϊָ��Introduction�����ı�����
    {
        Intro.Settext(str);
    }
    
    public void Click_checktasks()
    {
        //AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
        taskspanel.SetActive(true);
        

    }

    public void Click_NextDay()//����л���һ��
    {
        Enter_NextDay();
    }
    //public void Enter_NextDay()//����л���һ��
    //{
    //    if (!IsPause && !IsGameOver)
    //    {
    //        AddScore(Movepoint_num * 10);
    //        if (Date_left > 0)
    //        {
    //            calendar.GetComponent<Animator>().Play("TurnPage");
    //            calendar.SetTexT(Date + 1, Date_left - 1);
    //            TransitonPanel_1.SetActive(true);
    //            TransitonPanel_1.GetComponent<Animator>().Play("TP_1");

    //            //Calendar.GetComponent<Script>().dayminus;

    //        }
    //        else
    //        {
    //            IsGameOver = true;
    //            IsPause = true;
    //            Time.timescale = 0;
    //            GameOverPanel.SetActive(true);
    //            yourscore.text = "猫猫满意度：" + Score.ToString();
    //            endtext.text = "你输了";
    //            animator_fail.SetActive(true);
    //            animator_fail.GetComponent<Animator>().Play("F");

    //        }
    //    }

    //}
    public void Victory()
    {
        SceneManager.LoadScene("win");
        //endtext.text = "你赢了";
        //animator_success.SetActive(true);
        //animator_success.GetComponent<Animator>().Play("S");
    }
    public void Fail()
    {
        SceneManager.LoadScene("fail");
        //yourscore.text = "猫猫满意度：" + Score.ToString();
        //endtext.text = "你输了";
        //animator_fail.SetActive(true);
        //animator_fail.GetComponent<Animator>().Play("F");
    }
}
