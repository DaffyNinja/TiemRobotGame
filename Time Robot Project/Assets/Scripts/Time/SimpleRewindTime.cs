using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleRewindTime : MonoBehaviour {
	
    // Add to player
     
    public List<Vector3> movements;
    int movementIndex = 0;
    bool rewinding;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!rewinding)
        {
            movements.Add(gameObject.transform.position);
            
            movementIndex++;
        }

        if (movementIndex > movements.Count - 1)
        {
            movementIndex = movements.Count;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rewinding = true;
            Rewind();
        }
        else
        {
            rewinding = false;
        }



    }

    void Rewind()
    {
        movementIndex--;
        transform.position = movements[movementIndex];
        movements.RemoveAt(movementIndex);
       
    }
}
