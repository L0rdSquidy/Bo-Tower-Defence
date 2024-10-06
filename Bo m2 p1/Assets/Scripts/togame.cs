using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class togame : MonoBehaviour
{
    float timeelapsed = 0;


    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed >= 3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
