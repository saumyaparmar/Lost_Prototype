using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimation : MonoBehaviour
{
    public Animation[] anims;
    public static IDictionary<int, bool> animations = new Dictionary<int, bool>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(anims[0]);
        for (int i = 0; i < anims.Length; i++)
        {
            animations.Add(i, false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //Debug.Log(other.gameObject.GetComponentInParent<Animation>());
            
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < anims.Length; i++)
                {
                    if (other.gameObject.GetComponentInParent<Animation>() == anims[i])
                    {
                        if (animations[i] == false && anims[i].isPlaying == false)
                        {
                            anims[i].Play("Open");
                            animations[i] = true;
                            //Debug.Log(animations[i]);
                        }
                        else if (animations[i] == true && anims[i].isPlaying == false)
                        {
                            anims[i].Play("Close");
                            animations[i] = false;
                            //Debug.Log(animations[i]);
                        }
                    }
                }
            }
        }
    }
}
