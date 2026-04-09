using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public Slot[] slots;
    void Awake()
    {
        ClearAllSlots();

        if (RuntimeInventory.Instance != null)
            RuntimeInventory.Instance.OnInventoryUpdated += RefreshUI;
        //else
            //Debug.LogError("RuntimeInventory Instance not Found");
    }

    void OnEnable()
    {
        DeselectAllSlots();
        RefreshUI();
    }
    void ClearAllSlots()
    {
        foreach (Slot slot in slots)
            slot.ClearSlot();
    }

    public void RefreshUI()
    {
        if (RuntimeInventory.Instance == null) return;

        List<ItemData> caughtItems = RuntimeInventory.Instance.GetCaughtItems();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < caughtItems.Count)
                slots[i].SetItem(caughtItems[i]);
            else
                slots[i].ClearSlot();
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].selectedHighlight.SetActive(false);
        }
    }

    void OnDestroy()
    {
        if (RuntimeInventory.Instance != null)
            RuntimeInventory.Instance.OnInventoryUpdated -= RefreshUI;
    }
}
