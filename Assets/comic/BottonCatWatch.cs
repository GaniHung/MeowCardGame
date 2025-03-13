using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonCatWatch : MonoBehaviour
{
    public GameObject catWatch;
    private void OnMouseDown()
    {
        if(catWatch.activeInHierarchy==false)
        catWatch.SetActive(true);

    }
}
