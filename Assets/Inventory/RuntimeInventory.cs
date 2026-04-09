using System.Collections.Generic;
using UnityEngine;

public class RuntimeInventory : MonoBehaviour
{
    public static RuntimeInventory Instance;

    //stores caught as items
    private List<ItemData> caughtItems = new List<ItemData>();

    //tracks species caught at least once
    private HashSet<ItemData> discoveredSpecies = new HashSet<ItemData>();

    //tell the UI when to refresh
    public delegate void InventoryUpdatedHandler();
    public event InventoryUpdatedHandler OnInventoryUpdated;

    //fire on first catch of species
    public delegate void SpeciesDiscoveredHandler(ItemData item);
    public event SpeciesDiscoveredHandler OnSpeciesDiscovered;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData item)
    {
        if (item == null)
        {
            Debug.LogError("AddItem received a null ItemData.");
            return;
        }
        if (string.IsNullOrEmpty(item.itemName))
        {
            Debug.LogError("AddItem received an ItemData with no name. " + "Check that itemName is set on the asset in the Inspector.");
            return;
        }
        caughtItems.Add(item);
        OnInventoryUpdated?.Invoke();

        //fire on first catch per species
        if (item.itemType == ItemType.Fish && !discoveredSpecies.Contains(item))
        {
            discoveredSpecies.Add(item);
            OnSpeciesDiscovered?.Invoke(item);
        }
    }

    public List<ItemData> GetCaughtItems() => caughtItems;

    //for logbookentry to check if fish has been caught
    public bool isDiscovered(ItemData item) => discoveredSpecies.Contains(item);

    //when logbook needs full list
    public HashSet<ItemData> GetDiscoveredSpecies() => discoveredSpecies;
}