using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Setup(){
        Debug.Log("Turn background on");
        gameObject.SetActive(true);
        
    }

    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }

}
