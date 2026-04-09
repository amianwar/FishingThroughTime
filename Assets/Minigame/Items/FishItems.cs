using UnityEngine;

public enum TimePeriod { PresentDay, Cenozoic, Mesozoic, Paleozoic }

[CreateAssetMenu(fileName = "NewFish", menuName = "Inventory/Fish")]
public class FishItems : ItemData
{
    public string[] items;
    public double[] chance;
}
