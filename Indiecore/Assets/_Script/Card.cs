using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public string cardName;
    public string cardDesc;
    public Sprite cardSprite;
    public Sprite cardBackSprite;

}


//Eğer buraya kadar geldiysen iyi bir yazılımcısın demektir... bu elindeki güç seni şaha da kaldırır, seni yere de batırır.
//Kulak verin bu dediklerime hayat bazen karttan ibaret değil midir ?...