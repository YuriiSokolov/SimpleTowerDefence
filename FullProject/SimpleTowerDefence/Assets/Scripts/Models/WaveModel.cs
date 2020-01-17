using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveModel
{
    public string sequenceOfEnemies;

    public WaveModel()
    {
        
    }

    public WaveModel(string sequenceOfEnemies)
    {
        this.sequenceOfEnemies = sequenceOfEnemies;
    }

    public string SequenceOfEnemies
    {
        get
        {
            return sequenceOfEnemies;
        }
    }
}
