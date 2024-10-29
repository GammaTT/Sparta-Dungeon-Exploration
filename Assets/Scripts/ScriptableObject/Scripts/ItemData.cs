using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/ConsumableItem")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string ItemDescription;

    public float itemDuration;
    [Range(1f, 100f)] public int itemEffect;
}
