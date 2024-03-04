using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] private float cdTime;
    private float nextCast;

    public bool cd => Time.time < nextCast;
    public void StartCD() => nextCast = Time.time + cdTime;
}
