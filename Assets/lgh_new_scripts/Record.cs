using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public static Record Instance;
    // Start is called before the first frame update
    public int scenenum=1;
    public int totalScore=0;
  
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ȷ��AudioManager��������Ϸ�����г�������
        }
        
    }
}
