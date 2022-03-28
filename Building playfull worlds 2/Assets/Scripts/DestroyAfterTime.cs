using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] float timeBeforeDestroy;

    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }
}
