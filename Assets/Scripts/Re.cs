using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Re : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnMouseDown()
    {    
        GameObject.Find("putcard").GetComponent<AudioSource>().Play();
            Debug.Log("come");
        SceneManager.LoadScene("MainMenu"); 
    }
}
