using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerSurvey survey;

    private void Awake()
    {
        GameManager.Instance.player = this;

        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        survey = GetComponent<PlayerSurvey>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
