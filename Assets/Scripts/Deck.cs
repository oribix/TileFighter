using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    //40 cards
    private List<Card> deck;
    public Card Blast;

    void Start()
    {
        initDeck();
    }

    void initDeck()
    {
        for(int i = 0; i < 40; i++)
        {
            deck.Add(Blast);
        }
    }

    void useTopCard()
    {
        
    }
}
