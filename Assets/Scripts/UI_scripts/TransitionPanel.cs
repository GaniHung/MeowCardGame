using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPanel : MonoBehaviour
{


    public void CallRenew()
    {
        UIManager.Instance.RenewUI();
    }
    public void self_inactive()
    {
        gameObject.SetActive(false);
    }
 
}
