using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Column Type", menuName = "Column Type")]
public class ColumnType : ScriptableObject
{
    Color blockColor;
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

    //URGENT: il faut faire attention a colorSet[0]:
    // tjrs faire une double check avec le pickup color tool
    //+faut faire le meme control entre autre scriptable objects

    

}
