using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandColHandler : MonoBehaviour
{
    private Hand ownerHand;
    private void Start()
    {
        ownerHand = transform.GetComponent<Hand>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool checkisGameObj = other.GetComponent<CardDisplay>()._isCardInitToGame;
        if (!checkisGameObj)
        {
            other.GetComponent<CardDisplay>()._preview = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        bool checkisGameObj = other.GetComponent<CardDisplay>()._isCardInitToGame;
        if (checkisGameObj)
        {
            other.GetComponent<CardDisplay>()._preview = true;
        }
    }
}
