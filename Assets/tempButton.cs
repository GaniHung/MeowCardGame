using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tempButton : MonoBehaviour
{

    private void OnMouseDown()
    {   
        cardwatching cathis = GameObject.Find("cardwatching").GetComponent<cardwatching>();
        Debug.Log(this.gameObject.name);
        cathis.close();
    }

}
