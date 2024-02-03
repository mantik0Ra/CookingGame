using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SlicebleKitchenObjectSO : ScriptableObject
{
    public string name;
    public Transform prefab;
    public Sprite sprite;
    public float maxProgress = 1f;
}
