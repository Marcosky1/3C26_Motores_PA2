using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Puntaje", menuName ="Puntaje")]
public class Puntaje : ScriptableObject
{
    public int ScoreActual;
    public int ScoreMax;

    public bool UpdateMaxPuntaje()
    {
        if (ScoreActual >= ScoreMax)
        {
            ScoreMax = ScoreActual;
            return true;
        }
        else{ return false; }
    }


}
