using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lghControlwithout : MonoBehaviour
{
    Record ret;
    // Start is called before the first frame update
    int n; int now = 1;
    GameObject[] pictures;
    int cnt=12;
    private void Start()
    {
        ret = GameObject.Find("Record").GetComponent<Record>() ;
        n = cnt;
        pictures = new GameObject[n + 1];
        for (int i = 1; i <= n; i++)
        {
            pictures[i] = new GameObject();
            pictures[i] = GameObject.Find(i.ToString());
            pictures[i].SetActive(false);
        }
        now = 1;
        pictures[now].SetActive(true);

    }
    private void OnMouseDown()
    {
        if(now<n)
        pictures[now].SetActive(false);
        now++;
        if (now > n)
        {
            ret.scenenum = 1;
            SceneManager.LoadSceneAsync("SampleScene-dly", LoadSceneMode.Single);
        }
        else
        {
            pictures[now].SetActive(true);
        }
    }
}
