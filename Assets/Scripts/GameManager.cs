using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> Deck=new List<Card>();
    public Transform[] Slots;
    private bool[] slotavilable;
    
    public void Draw()//·¢ÅÆ
    {
        if (Deck.Count > 0)
        {
            Card randcard = Deck[Random.Range(0, Deck.Count)];
            for (int i = 0; i < Slots.Length; i++) {
                if (slotavilable[i] == true)
                {   
                    randcard.gameObject.SetActive(true);
                    randcard.transform.position = Slots[i].transform.position;
                    slotavilable[i] = false;
                    Deck.Remove(randcard);

                    return;
                }
            }
        }
    }
    public void Shuffle()
    {

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
