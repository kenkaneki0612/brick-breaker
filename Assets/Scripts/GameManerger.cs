using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManerger : MonoBehaviour
{

    private static GameManerger gameManerger;

    private void Awake()
    {
        if (gameManerger != null)
        {
            return;
        }

        gameManerger = this;
        DontDestroyOnLoad(this);
    }
   
}
