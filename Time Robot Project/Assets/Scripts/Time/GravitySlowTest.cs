using UnityEngine;
using System.Collections;

public class GravitySlowTest : MonoBehaviour {

    public float fallSpeed;
    public float slowSpeed;

    Rigidbody2D rig2D;

	// Use this for initialization
	void Start ()
    {
        rig2D = GetComponent<Rigidbody2D>();

        fallSpeed = rig2D.gravityScale;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            fallSpeed = 0;
        }
        else
        {
            fallSpeed = 1;
        }

        Vector2 objVelocity = new Vector2(0, rig2D.velocity.y * fallSpeed);
        rig2D.velocity = objVelocity;
	
	}
}
