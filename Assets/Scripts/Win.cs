using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void Setup(){
        Debug.Log("Turn background on");
        gameObject.SetActive(true);
        
    }

    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }

    
}
