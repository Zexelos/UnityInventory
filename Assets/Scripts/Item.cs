using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string Name => itemName;
    public float Weight => itemWeight;

    [SerializeField] string itemName = default;
    [SerializeField] float itemWeight = default;
}
