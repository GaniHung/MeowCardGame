using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    public List<GameObject> MovePoint_list=new List<GameObject>();
   
    public UIManager UIManager;//��ǰ�ĵ���
    public void MovePointsUpdate(int update_num)
    {
        if (update_num <=UIManager.Movepoint_num)
        {

            for (int i = UIManager.Movepoint_num - update_num; i < UIManager.Movepoint_num; i++)
            {
                MovePoint_list[i].SetActive(false);
            }

        }
    }
    public void Renew_MovePoints()
    {   for (int i = 0; i < MovePoint_list.Count; i++)
            MovePoint_list[i].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
