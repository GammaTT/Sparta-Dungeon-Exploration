using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    PlayerCondition playerCondition;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        playerCondition = GameManager.Instance.Player.condition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            playerCondition.HealthChange(-damage);
        }
    }
}
