using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UncookedSO : ScriptableObject
{
    public string name;
    public Transform[] cookedPrefabs;
    public Transform uncookedPrefab;
    public Transform cookedPrefab;
    public Transform burnedPrefab;
    public float cookedTime = 3f;

}
