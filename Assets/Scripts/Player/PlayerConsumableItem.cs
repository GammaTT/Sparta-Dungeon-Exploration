using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsumableItem : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void UseItem(Item item)
    {
        StartCoroutine(item.ItemEffect(player));
    }
}
