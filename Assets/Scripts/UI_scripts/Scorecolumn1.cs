using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Scorecolumn1 : MonoBehaviour
{
    [SerializeField] private UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {   
        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        RectTransform re = GetComponent<RectTransform>();
        re.localScale = new Vector3(re.localScale.x, 0, re.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Scale(float score)
    {



        RectTransform re = GetComponent<RectTransform>();
        re.localScale = new Vector3(re.localScale.x, (score / uimanager.Score_Max) * 2.1f, re.localScale.z);

    }
}
