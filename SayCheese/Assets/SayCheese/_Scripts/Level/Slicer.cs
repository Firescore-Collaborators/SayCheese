using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using NaughtyAttributes;

public class Slicer : MonoBehaviour
{
    public Material crossMat;
    public GameObject sliceObject;
    bool recursiveSlice;
    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossMat);
    }

    [Button]
    public void Slice()
    {
        if (!recursiveSlice)
        {
            SlicedHull hull = SliceObject(sliceObject, crossMat);

            if (hull != null)
            {
                hull.CreateLowerHull(sliceObject, crossMat);
                hull.CreateUpperHull(sliceObject, crossMat);

                sliceObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Slice();
        }
    }

}
