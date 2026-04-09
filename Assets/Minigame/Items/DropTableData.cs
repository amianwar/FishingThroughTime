using UnityEngine;

[CreateAssetMenu(fileName = "DropTableData", menuName = "Inventory/DropTableData")]
public class DropTableData : ScriptableObject
{
    [System.Serializable]
    public class DropEntry
    {
        public ItemData item;
        [Range(0, 100)]
        public float chance;
    }

    public DropEntry[] entries;
}
