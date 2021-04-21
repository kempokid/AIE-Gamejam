using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatedProgression : MonoBehaviour
{
    public int collectibleThreshold;
    public CollectibleManager collectibleManager;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fridge")
        {
            if(collectibleManager.collectibles >= collectibleThreshold)
            {
                Destroy(this.gameObject);
                collectibleManager.collectibles--;
            }
            else
            {
                Debug.Log("Hey, this doesn't work");
            }
        }
    }
}
