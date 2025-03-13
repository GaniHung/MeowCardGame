using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void Button_Move()
    {
        UIManager.Instance.Minus_MovePoints(1);
    }
    public void Button_MoveTwice()
    {
        UIManager.Instance.Minus_MovePoints(2);
    }
    
}
