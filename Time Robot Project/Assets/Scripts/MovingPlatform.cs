using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{

    [Header("Positions")]
    public float fSpeed;
    private bool bIsMovingToEnd = true;
    public Transform tStart;
    public Transform tEnd;
    private Vector3 vStart;
    private Vector3 vEnd;
    private float fMoveTimer = 0f;

    void Start()
    {
        vStart = tStart.position;
        // tStart = transform;
        vEnd = tEnd.position;
        transform.position = vStart;
    }

    void Update()
    {
        fMoveTimer = Mathf.Clamp(fMoveTimer, 0, 1);

        if (bIsMovingToEnd)
        {
            fMoveTimer += fSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(vStart,
                                              vEnd,
                                              fMoveTimer);

            if (fMoveTimer >= 1f)
            {
                bIsMovingToEnd = false;
            }
        }
        else
        {
            fMoveTimer -= fSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(vStart,
                                              vEnd,
                                              fMoveTimer);
            if (fMoveTimer <= 0f)
            {
                bIsMovingToEnd = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Parents the player to the platform so they both move
            col.transform.parent = gameObject.transform;

            print("Player");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //The player is no longer a child of the platform
            col.transform.parent = null;
            if (col.gameObject.GetComponent<PlayerMove>().flipMove >= 1)
            {
                col.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (col.gameObject.GetComponent<PlayerMove>().flipMove <= -1)       // TO BE FIXED
            {
                col.transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }
}
