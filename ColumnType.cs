using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Column Type", menuName = "Column Type")]
public class ColumnType : ScriptableObject
{
    public Color blockColor;
    //public Color changedColor = Color.yellow;
    public int amount = 5;
    public Color[] colorSet;
    public void Awake() 
    {
        colorSet  = new Color[amount];
    }

    void ColorSet(int amount)
    {
        for (int i=0; i<amount; i++)
        {
            colorSet[i] = blockColor;
        }
    }

}
