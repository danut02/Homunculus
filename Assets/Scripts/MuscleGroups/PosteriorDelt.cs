using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PosteriorDelt : IMuscle
{
    private int development;

    public void setDevelopment(int value)
    {
        development = value;
    }
    public int getDevelopment()
    {
        return development;
    }
}