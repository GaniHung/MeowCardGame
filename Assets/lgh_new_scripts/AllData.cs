using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class AllData : MonoBehaviour
{

    static Record Rethis;
    TasksManager Tmthis;
    // Start is called before the first frame update
    static string[] taskGroup1= { "A", "B", "C", "D", "ABD", "CC", "A", "DCA", "B", "ABCD" };
    static int[] cntTaskGroup1= { 4, 3, 3, 0, 0, 0 };//6
    static int[] ddl1={ 4, 4, 4, 4, 5, 5, 5, 6, 6, 6 };
    static string[] taskGroup2 = { "A", "B", "C", "D", "AD", "BC", "CA", "BA", "CAB", "DB", "C", "DD", "BAB", "CA", "CBC", "DA", "ABCD", "ABCD" };
    static int[] cntTaskGroup2 = { 4, 3, 3, 3, 3, 2, 0, 0, 0 };//9
    static int[] ddl2 = { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 9, 9, 9, 9, 9, 9, 9, 9 };
    static string[] taskGroup3 = { "A", "B", "C", "C", "BA", "AC", "AC", "DD", "BD", "A", "C", "AC", "B", "CAB", "DC", "DD", "A", "CB", "C", "BA", "D", "ABCD", "ABCD", "BCA" };
    static int[] cntTaskGroup3 = { 3, 3, 2, 3, 2, 2, 4, 2, 3, 0, 0, 0 };//12
    static int[] ddl3 = { 6, 6, 6, 6, 6, 6, 6, 6, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 12, 12, 12, 12, 12, 12 };
    public class InputTaskGroup
    {    
        //public static InputTaskGroup Instance { get; private set; }
    public string[] taskGroup ;
    public int[] cntTaskGroup ;
    public int[] ddl; 

        public void initInput()
        {
            int chapter = Rethis.scenenum;
            if (chapter == 1)
            {
                taskGroup = taskGroup1;
                cntTaskGroup = cntTaskGroup1;
                ddl = ddl1;
            }
            if (chapter == 2)
            {
                taskGroup = taskGroup2;
                cntTaskGroup = cntTaskGroup2;
                ddl = ddl2;
            }
            if (chapter == 3)
            {
                taskGroup = taskGroup3;
                cntTaskGroup = cntTaskGroup3;
                ddl = ddl3;
            }
        }
    }

    //public  InputTaskGroup data;
    //build map
    public Dictionary<string, string> mp = new Dictionary<string, string>();
    public string[] textMap;
    public string[] taskGroupMap;
    private void Awake()
    {
        textMap =new string[]{ "程序开发", "产出创意", "美工创作", "音乐写作", "动画制作", "挑选音效", "确定风格", "动作设计", "音效配合", "人物设计", "制作PV", "关卡设计", "实机录制", "演出实现", "合并管线", "音乐写作pro", "动作设计pro", "人物设计pro", "美工创作pro" };
        ;       taskGroupMap = new string []{ "A", "B", "C", "D", "AC", "BD", "CD", "AB", "AD", "BC", "BCD", "ABC", "ABD", "ACD", "ABCD" , "DD", "BAB","CBC","CC" };
        ;
    }
    bool[] com = {false,false,false,false,false};
    void dfs(string ori,string temp,int mpindex)
    {
        //Debug.Log(temp);
        //Debug.Log(ori);
        if (temp.Length == ori.Length)
        {
            mp.Add(temp, textMap[mpindex]);
            //Debug.Log(temp);
            return;
        }
        for(int i = 0; i < ori.Length; i++)
        {
            if (com[i] == true) continue;
            com[i] = true;
            dfs(ori, temp + ori[i],mpindex);
            com[i] = false;
        }
    }
    public UIManager UIthis;
    private void Start()
    {

        //Debug.Log(1);
        Rethis = GameObject.Find("Record").GetComponent<Record>();
        //data = new InputTaskGroup();
        //InputTaskGroup.Instance.initInput(Rethis.scenenum);
        Tmthis = GameObject.Find("scripts").GetComponent<TasksManager>();

        //Debug.Log(taskGroupMap.Length);
        for (int i = 0; i <taskGroupMap.Length; ++i)
        {
            if(i<=14)
            dfs(taskGroupMap[i],"",i);
            else
            mp.Add(taskGroupMap[i], textMap[i]);
        }
        UIthis = GameObject.Find("UIManager").GetComponent<UIManager>();
        UIthis.Init();
        //Tmthis.Init();
    }
    public void getdata()
    {

    }
}
