using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lghControl : MonoBehaviour
{
    // Start is called before the first frame update
    int n; int now = 1;
    GameObject[] pictures;
    int cnt = 11;
    private void Start()
    {   
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
        if (now < n)
        {
            //if (now == 1) pictures[1].GetComponent<Animator>().Play("1_out");
            //Animator animator = pictures[now].GetComponent<Animator>();
            //animator.Play(now.ToString() + "_out");
            pictures[now].SetActive(false);
        }
            
            
        now++;
        if (now > n)
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }
        else
        {

            pictures[now].SetActive(true);
            //Animator animator = pictures[now].GetComponent<Animator>();
            //animator.Play(now.ToString() + "_in");
        }
    }
}
