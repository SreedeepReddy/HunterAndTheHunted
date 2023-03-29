using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Storable Object")]
public class StorableObject : ScriptableObject
{
    public int object_id;
    public GameObject gameObj;
    public Sprite objectSprite;
}