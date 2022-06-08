using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using BzKovSoft.ObjectSlicer.Samples;
using Deform;

public class SliceController : MonoBehaviour
{
    public GameObject knife;
    public CapsuleCollider knifeCollider;
    public BendDeformer knifeDeformer;
    Vector3 startPos;

    public float knifeDownLimit = 0.2f;
    public float knifeSpeed;

    bool mouseHeld;
    bool knifeReached;

    void Start()
    {
        startPos = knife.transform.position;
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown(); 
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp();
        }

        KnifeMovement();
    }


    void OnMouseButtonDown()
    {
        knifeCollider.enabled = true;
        mouseHeld = true;
    }

    void OnMouseButtonUp()
    {
        knifeCollider.enabled = false;
        mouseHeld = false;
    }

    void KnifeMovement()
    {
        if(!mouseHeld) return;
        float posy = knife.transform.position.y;
        posy -= Time.deltaTime * knifeSpeed;
        if(posy <= knifeDownLimit)
        {
            knifeReached = true;
            posy = knifeDownLimit;
            mouseHeld = false;
            LerpObjectPosition.instance.LerpObject(knife.transform, startPos, 0.5f);
        }
        knife.transform.position = new Vector3(knife.transform.position.x, posy, knife.transform.position.z);
    }
}
