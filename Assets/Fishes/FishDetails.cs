using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewFishDetails", menuName = "Fish Details")]
public class FishDetails : ScriptableObject
{
    public String fishName;
    [TextArea]
    public String description;
    public Sprite fishImg;
    public bool caughtByPlayer;
}
