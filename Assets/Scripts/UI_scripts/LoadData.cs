using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class LoadData : MonoBehaviour
{

    public Vector3[,] handcard_pos=new Vector3[8,2];
    public Vector3[,,] taskPosition;//the 3-D array of positions to place task-cards
    public Vector3[] card_slot_array;
    public Transform[] array_0_0;
    public Transform[] array_0_1;
    public Transform[] array_1_0;
    public Transform[] array_1_1;
    public Transform[] array_2_0;
    public Transform[] array_2_1;
    public Transform[] array_3_0;
    public Transform[] array_3_1;
    public Transform outliner;
    // Start is called before the first frame update
    public void function()
    {
        taskPosition = new Vector3[21, 201, 2];
        card_slot_array = new Vector3[21 * 201 * 2];
        for (int i = 0; i < card_slot_array.Length; i++)
        {
            //card_slot_array[i] = new GameObject().transform.position;
            card_slot_array[i] = outliner.transform.position;


        }
        //for (int i = 0; i < 8; i++)
        //{
        //    card_slot_array[i] = array_0_0[i].position;
        //}

        //for (int i = 21 * 1; i < 21 * 1 + 8; i++)
        //{
        //    card_slot_array[i] = array_0_1[i].position;
        //}

        //for (int i = 21 * 2; i < 21 * 2 + 4; i++)
        //{
        //    card_slot_array[i] = array_1_0[i].position;
        //}
        //for (int i = 21 * 3; i < 21 * 3 + 4; i++)
        //{
        //    card_slot_array[i] = array_1_1[i].position;
        //}
        //for (int i = 21 * 4; i < 21 * 4 + 4; i++)
        //{
        //    card_slot_array[i] = array_2_0[i].position;
        //}
        //for (int i = 21 * 5; i < 21 * 5 + 4; i++)
        //{
        //    card_slot_array[i] = array_2_1[i].position;
        //}
        //for (int i = 21 * 6; i < 21 * 6 + 4; i++)
        //{
        //    card_slot_array[i] = array_3_0[i].position;
        //}
        //for (int i = 21 * 7; i < 21 * 7 + 4; i++)
        //{
        //    card_slot_array[i] = array_3_1[i].position;
        //}


        for (int x = 0; x < 21; x++)
        {
            for (int z = 0; z < 2; z++)
            {
                for (int y = 0; y < 201; y++)
                {

                    taskPosition[x, y, z] = new Vector3(20,0,0);

                }
            }
        }

        for (int i = 0; i < 8; i++)
        {

            if (i < 5)
                taskPosition[0, i, 0] = new Vector3(-3 + 2 * i, 3, 0);
            else
                taskPosition[0, i, 0] = new Vector3(5 + (i - 5) * 0.7f, 3.2f + (i - 5) * 0.2f, 0);
        }
        for (int i = 0; i < 8; i++)
        {

            if (i < 5)
                taskPosition[0, i, 1] = new Vector3(-3 + 2 * i, 2.6f, 0);
            else
                taskPosition[0, i, 1] = new Vector3(5 + (i - 5) * 0.7f, 2.8f + (i - 5) * 0.2f, 0);
        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[1, i, 0] = new Vector3(-3.5f + 1 * i, 2, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[1, i, 1] = new Vector3(-3.5f + 1 * i, 1.7f, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[2, i, 0] = new Vector3(-3.5f + 1 * i, 1, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[2, i, 1] = new Vector3(-3.5f + 1 * i, 0.7f, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[3, i, 0] = new Vector3(-3.5f + 1 * i, 0, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[3, i, 1] = new Vector3(-3.5f + 1 * i, -0.3f, 0);

        }


      


    }
    public void definecardpos()
    {
        for(int i = 0; i < 8; i++)
        {
            if (i < 5)
                handcard_pos[i, 0] = new Vector3(-4 + 2 * i, -3.5f, 0);
            else
                handcard_pos[i, 0] = new Vector3(4 + (i - 5) * 0.7f, -3.3f + (i - 5) * 0.2f, 0);
            
        }
        for (int i = 0; i < 8; i++)
        {
            if (i < 5)
                handcard_pos[i, 1] = new Vector3(-4 + 2 * i, -3.9f, 0);
            else
                handcard_pos[i, 1] = new Vector3(4 + (i - 5) * 0.7f, -3.7f + (i - 5) * 0.2f, 0);

        }
    }
    private void defineposition()
    {
        for (int x = 0; x < 21; x++)
        {
            for (int z = 0; z < 2; z++)
            {
                for (int y = 0; y < 201; y++)
                {

                    taskPosition[x, y, z] = new Vector3(20, 0, 0);

                }
            }
        }

        for (int i = 0; i < 8; i++)
        {

            if (i < 5)
                taskPosition[0, i, 0] = new Vector3(-3 + 2 * i, 3, 0);
            else
                taskPosition[0, i, 0] = new Vector3(5 + (i - 5) * 0.7f, 3.2f + (i - 5) * 0.2f, 0);
        }
        for (int i = 0; i < 8; i++)
        {

            if (i < 5)
                taskPosition[0, i, 1] = new Vector3(-3 + 2 * i, 2.6f, 0);
            else
                taskPosition[0, i, 1] = new Vector3(5 + (i - 5) * 0.7f, 2.8f + (i - 5) * 0.2f, 0);
        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[1, i, 0] = new Vector3(-3.5f + 1 * i, 2, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[1, i, 1] = new Vector3(-3.5f + 1 * i, 1.7f, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[2, i, 0] = new Vector3(-3.5f + 1 * i, 1, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[2, i, 1] = new Vector3(-3.5f + 1 * i, 0.7f, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[3, i, 0] = new Vector3(-3.5f + 1 * i, 0, 0);

        }
        for (int i = 0; i < 4; i++)
        {


            taskPosition[3, i, 1] = new Vector3(-3.5f + 1 * i, -0.3f, 0);

        }
    }
    public void Out()
    {
        for(int i = 0; i < 8; i++)
        {
            print(handcard_pos[i,0]);
        }
    }

}
