using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToStartGame : MonoBehaviour
{
    float timeelapsed = 0;

    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed >= 5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
