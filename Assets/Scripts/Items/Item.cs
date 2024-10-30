using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemData itemData;
    
    public virtual IEnumerator ItemEffect(Player player)
    {
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        int playerLayer = LayerMask.NameToLayer("Player");

        if (other.gameObject.layer == playerLayer)
        {
            other.GetComponent<PlayerConsumableItem>().UseItem(this);
            Destroy(this.gameObject, 0.4f);

            Debug.Log("itemeffect");
        }
    }
}
