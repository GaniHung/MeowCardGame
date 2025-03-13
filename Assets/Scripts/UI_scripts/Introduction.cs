using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    [SerializeField] private Text text_introduction;   
    
    public void Settext(string str)
    {
        text_introduction.text = str;
    }
   
}
