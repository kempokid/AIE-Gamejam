using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
