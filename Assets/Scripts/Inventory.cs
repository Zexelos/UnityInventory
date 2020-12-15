using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] float maxWeight = 10f;
    [SerializeField] int capacity = 5;

    Item[] currentItems;
    float currentWeight;
    Item subscribedItem;
    GameObject subscribedGameObject;
    ItemHolder itemHolder;

    void Start()
    {
        currentItems = new Item[capacity];
        currentWeight = maxWeight;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            AddItem(subscribedItem);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        subscribedGameObject = other.gameObject;
        itemHolder = subscribedGameObject.GetComponent<ItemHolder>();
        Item item = subscribedGameObject.gameObject.GetComponent<ItemHolder>().Item;
        if (item != null)
        {
            subscribedItem = item;
            Debug.Log($"Subscribed: {item.Name}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Left");
        subscribedGameObject = other.gameObject;
        itemHolder = null;
        Item item = subscribedGameObject.gameObject.GetComponent<ItemHolder>().Item;
        if (item != null)
        {
            subscribedItem = null;
            subscribedGameObject = null;
            Debug.Log($"Unsubscribed: {item.Name}");
        }
    }

    void AddItem(Item item)
    {
        if (CanAddItem(item))
        {
            for (int i = 0; i < currentItems.Length; i++)
            {
                if (currentItems[i] == null)
                {
                    currentItems[i] = item;
                    Debug.Log($"Added: {item.Name}, {item.Weight}kg");
                    currentWeight -= item.Weight;
                    Debug.Log($"Current weight: {currentWeight}kg");
                    itemHolder.HideItemInfo();
                    Destroy(subscribedGameObject);
                    return;
                }
            }
        }
        else
            Debug.Log("Could not add an item");
    }

    bool CanAddItem(Item item)
    {
        int freeSlots = 0;

        foreach (var items in currentItems)
        {
            if (items == null)
            {
                freeSlots++;
            }
        }

        if (freeSlots > 0 && item.Weight < currentWeight)
            return true;
        else
            return false;
    }
}
