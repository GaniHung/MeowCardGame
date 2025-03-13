using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class moveAnime : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 toPosition;
    public float speed;
    //public void
    private void Start()
    {
        toPosition = this.gameObject.transform.position;
    }
    private void Update()
    {
        speed = 0.020f;
        Vector3 myPosition = this.gameObject.transform.position;
        if (toPosition != myPosition)
        {
            float deltaX = Vector3.Distance(toPosition, myPosition);
            if (deltaX <= speed) myPosition = toPosition;
            else
            {
                myPosition += (toPosition - myPosition) * speed / deltaX;
            }
        }
        this.gameObject.transform.position = myPosition;
    }  
       public void MoveTo(Vector3 record,bool needAnime)
    {
        if(needAnime) toPosition = record;
        else
        {
            toPosition = record;
            this.gameObject.transform.position = toPosition;
        }
    }
    public bool IsMoving()
    {
        return (!Mathf.Equals( toPosition,this.gameObject.transform.position));
    }
}
    

