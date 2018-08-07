using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaker : MonoBehaviour 

{

    public void ChangeLevel()

    {
        Application.LoadLevel(1);
    }

}

