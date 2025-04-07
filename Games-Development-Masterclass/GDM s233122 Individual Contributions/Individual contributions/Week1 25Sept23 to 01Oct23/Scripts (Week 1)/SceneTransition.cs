using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainScene", 5f);
    }

    // Update is called once per frame
    void LoadMainScene()
    {
        GameManager.Instance.LoadMainScene();
    }
}