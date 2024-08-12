using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        CheckChildSize();
    }

    void CheckChildSize()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            if (child.localScale.y > transform.localScale.y)
            {
                rend.material.color = Color.red;
                Destroy(child.gameObject);
            }
        }
    }
}
