using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    
    private Text OnScreenText;
    // Start is called before the first frame update
    void Awake()
    {
        OnScreenText = GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        OnScreenText.text = "Soldiers Saved: " + HelicopterMovement.soldiersRescued.ToString() +
        "\n" + "Soldiers in Helicopter: " + HelicopterMovement.currentCapacity.ToString();
    }
}
