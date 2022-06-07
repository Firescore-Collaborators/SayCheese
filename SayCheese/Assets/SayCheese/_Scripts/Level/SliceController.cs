using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicer.Samples;
public class SliceController : MonoBehaviour
{
    public GameObject objectToSlice;
    
    void Start()
    {
        if(objectToSlice.GetComponent<IBzSliceable>() == null)
        {
            Debug.LogError("Object to slice must have IBzSliceable component");
        }
    }
}
