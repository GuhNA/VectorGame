using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{

    [SerializeField] SpriteRenderer conection;

    float positionY;
    SpriteRenderer render;
    void Start() 
    {
        positionY = transform.position.y;
        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        print(conection.bounds.extents.y);
        if(conection.GetComponent<Transform>().localScale.y > 0)
        {
            transform.position = new Vector2(transform.position.x, positionY + conection.bounds.extents.y*2);
            render.enabled = true;
            transform.eulerAngles = Vector3.zero;
        }
        else if(conection.GetComponent<Transform>().localScale.y < 0)
        {
            transform.position = new Vector2(transform.position.x, positionY -conection.bounds.extents.y*2);
            transform.eulerAngles = new Vector3(0,0,180);
            render.enabled = true;
        }
        else render.enabled = false;    
    }
}
