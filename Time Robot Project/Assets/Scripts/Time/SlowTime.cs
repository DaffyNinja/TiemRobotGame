using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Time.timeScale = 0.5F;
        }
        else
        {
            Time.timeScale = 1F;
        }

    }
}
