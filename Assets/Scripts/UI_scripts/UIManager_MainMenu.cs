using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_MainMenu : MonoBehaviour
{
    public Record record;
    public GameObject choosepanel;
    private void Awake()
    {
        AudioManager.Instance.playbgm(AudioManager.Instance.menubgm);
        choosepanel.SetActive(false);
        record = GameObject.Find("Record").GetComponent<Record>();
    }
    public void Click_Play()
    {
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
        click_enterlevel_1();
        //SceneManager.LoadScene("SampleScene_1");
    }
    public void Click_load()
    {
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
        choosepanel.SetActive(true);
    }
    public void closechoosepanel()
    {
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
        choosepanel.SetActive(false);
    }
    public void Click_quit()
    {
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
        Application.Quit();
    }
    public void click_tutorial()
    {
        SceneManager.LoadSceneAsync("TutorialScene", LoadSceneMode.Single);
    }
    public void click_enterlevel_1()
    {
        record.scenenum = 1;
        SceneManager.LoadSceneAsync("SampleScene-dly", LoadSceneMode.Single);
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
    }
    public void click_enterlevel_2()
    {
        record.scenenum = 2;
        SceneManager.LoadSceneAsync("SampleScene-dly", LoadSceneMode.Single);
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
    }
    public void click_enterlevel_3()
    {
        record.scenenum = 3;
        SceneManager.LoadSceneAsync("SampleScene-dly", LoadSceneMode.Single);
        AudioManager.Instance.playsfx(AudioManager.Instance.button_1);
    }
}
