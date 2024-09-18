using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class togame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToGame()
    {
        new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
