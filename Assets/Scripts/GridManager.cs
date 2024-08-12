using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject parentPrefab;
    public GameObject childPrefab;
    public int rows = 3;
    public int columns = 3;
    public Color largerChildColor = Color.red;
    public Color defaultColor = Color.white;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                GameObject parent = Instantiate(parentPrefab, new Vector3(x * 2.0f, y * 2.0f, 0), Quaternion.identity);
                parent.transform.parent = transform;

                GameObject child = Instantiate(childPrefab, parent.transform);
                child.transform.localPosition = Vector3.zero;

                float randomSize = Random.Range(0.5f, 2.0f);
                child.transform.localScale = new Vector3(randomSize, randomSize, 1);
                SpriteRenderer parentRenderer = parent.GetComponent<SpriteRenderer>();
                SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

                if (parentRenderer != null && childRenderer != null)
                {
                    if (child.transform.localScale.y > parent.transform.localScale.y)
                    {
                        parentRenderer.color = largerChildColor;
                        Destroy(child);
                    }
                    else
                    {
                        parentRenderer.color = defaultColor;
                    }
                }
                else
                {
                    Debug.LogWarning("Missing SpriteRenderer component on parent or child prefab.");
                }
                if (child != null)
                {
                    child.transform.SetAsLastSibling();
                }
                Debug.Log($"Parent instantiated at ({x}, {y}) with child size: {child.transform.localScale}");
            }
        }
    }
}