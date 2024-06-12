using UnityEngine;

public class ArrowHead : MonoBehaviour
{

    [SerializeField] SpriteRenderer conection;

    float position;
    [SerializeField] bool arrowUp;
    SpriteRenderer render;
    void Start() 
    {
        if(arrowUp) position = transform.position.y;
        else position = transform.position.x;

        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        ArrowPos(arrowUp);
    }

    void ArrowPos(bool up)
    {
        if(up)
        {
            if(conection.GetComponent<Transform>().localScale.y > 0)
            {
                transform.position = new Vector2(transform.position.x, position + conection.bounds.extents.y*2);
                render.enabled = true;
                transform.eulerAngles = Vector3.zero;
            }
            else if(conection.GetComponent<Transform>().localScale.y < 0)
            {
                transform.position = new Vector2(transform.position.x, position - conection.bounds.extents.y*2);
                transform.eulerAngles = new Vector3(0,0,180);
                render.enabled = true;
            }
            else render.enabled = false;  
        }
        else
        {
            if(conection.GetComponent<Transform>().localScale.y > 0)
            {
                transform.position = new Vector2(position + conection.bounds.extents.x*2, transform.position.y);
                render.enabled = true;
                transform.eulerAngles = new Vector3(0,0,270);
            }
            else if(conection.GetComponent<Transform>().localScale.y < 0)
            {
                transform.position = new Vector2(position -conection.bounds.extents.x*2,transform.position.y);
                transform.eulerAngles = new Vector3(0,0,90);
                render.enabled = true;
            }
            else render.enabled = false;  
        }
    }
}
