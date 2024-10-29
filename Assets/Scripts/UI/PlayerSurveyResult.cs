using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSurveyResult : MonoBehaviour
{
    GameObject playerLookObject => GameManager.instance.player.survey.hitObject;
    TextMeshProUGUI playerSurveyResultText;


    private void Awake()
    {
        playerSurveyResultText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string text;

        if (playerLookObject == null)
        {
            text = $"보고있는 물체 : 없음";
        }
        else
        {
            text = $"보고있는 물체 : {playerLookObject.name}";
        }
        playerSurveyResultText.text = text;
    }
}
