using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    bool isFollowing;

    public CollectibleManager collectibleManager;

    public float rotationSpeed = 1;
    public float circleRadius = 1;
    public float elevationOffset = 0;

    public bool rotatesAroundPlayer;
    public bool canCollect;

    private Vector3 positionOffset;
    private float angle;



    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
        canCollect = true;
    }


    private void Update()
    {
        if (rotatesAroundPlayer)
        {
            CircleTarget();
        }
        else
        {
            FollowTarget();
        }        
    }

    private void CircleTarget()
    {
        if (isFollowing)
        {
            positionOffset.Set(
            Mathf.Cos(angle) * circleRadius,
            elevationOffset,
            Mathf.Sin(angle) * circleRadius
            );
            transform.position = objectToFollow.position + positionOffset;
            angle += Time.deltaTime * rotationSpeed;
            if (canCollect)
            {
                collectibleManager.collectibles++;
                canCollect = false;
            }
        }
    }

    private void FollowTarget()
    {
        if (isFollowing)
        {
            transform.position = objectToFollow.position + offset;
            if (canCollect)
            {
                collectibleManager.collectibles++;
                canCollect = false;
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Fridge")
        {
            isFollowing = true;
        }
    }
}
