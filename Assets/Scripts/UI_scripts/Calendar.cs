using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{   
    public TextMeshProUGUI signal;
    public TextMeshProUGUI Date_left;
    public TextMeshProUGUI Date;


    public void SetTextActive()
    {
        signal.gameObject.SetActive(true);
        Date_left.gameObject.SetActive(true);
        Date.gameObject.SetActive(true);
    }
    public void SetTextInactive()
    {
        signal.gameObject.SetActive(false);
        Date_left.gameObject.SetActive(false);
        Date.gameObject.SetActive(false);

    }
    public void SetTexT(int date,int dateleft)
    {
        //in
         UIManager Uithis = GameObject.Find("UIManager").GetComponent<UIManager>();
        Date.text=date.ToString();
        Date_left.text=(Uithis.All+1).ToString();
    }
}

