using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenestart : MonoBehaviour {

    public void ChangeScene(string scenename)
    {
        Application.LoadLevel(scenename);

    }
	
}
