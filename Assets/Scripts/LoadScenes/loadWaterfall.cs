using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadWaterfall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player"){
            Debug.Log("Tried to enter waterfall");
            SceneManager.LoadScene("Waterfall1");
        }
    }
}
