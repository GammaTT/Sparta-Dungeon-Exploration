using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HastePotion : Item
{
    PlayerController controller;

    public override IEnumerator ItemEffect(Player player)
    {
        controller = player.controller;

        float duration = itemData.itemDuration;
        float originSpeed = controller.moveSpeed;
        float speedMulti = itemData.itemEffect * 0.01f;

        controller.moveSpeed = originSpeed * speedMulti;

        while (true)
        {
            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                controller.moveSpeed = originSpeed;

                break;
            }

            yield return null;
        }
    }
}
