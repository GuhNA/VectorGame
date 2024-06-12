using UnityEngine;

public class ResultantVector : MonoBehaviour
{
    [SerializeField] SpriteRenderer boundsY;
    float moveY;
    float moveX;
    [SerializeField] SpriteRenderer boundsX;
    [SerializeField] Transform resultantArrow;
    public Vector2 pos;
    // Update is called once per frame
    float posX, posY;
    float ca, co, tg, xPai, yPai, deg;

    private void Start() 
    {
        posX = transform.position.x;
        posY = transform.position.y;
        xPai = -1*boundsX.GetComponentInParent<Transform>().position.x;
        yPai = -1*boundsX.GetComponentInParent<Transform>().position.y;
    }
    void Update()
    {
        moveY = boundsY.GetComponent<Transform>().localPosition.y;
        moveX = boundsX.GetComponent<Transform>().localPosition.x;
        calcTg();



        if(moveX > 0) pos = new Vector2(posX + (boundsX.bounds.extents.x*2 + moveX), pos.y);   
        else 
        {
            pos = new Vector2(posX + (-boundsX.bounds.extents.x*2 + moveX), pos.y);
        }

        if(moveY > 0) 
        {
            pos = new Vector2(pos.x, posY + (boundsY.bounds.extents.y*2 + moveY));  
             if(moveX < 0) deg = 180 + deg;
        }  
        else 
        {
            pos = new Vector2(pos.x, posY + (-boundsY.bounds.extents.y*2 + moveY));
            //if(moveX < 0) deg = 180 + deg;
        }
        if(moveX < 0 && moveY < 0) deg = -180 + deg;
        
        resultantArrow.eulerAngles = new Vector3(0,0,-(90-deg));
        print(-(90-deg));
        resultantArrow.transform.position = new Vector2(pos.x, pos.y);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        GetComponent<LineRenderer>().SetPosition(1,pos);
    }

    void calcTg()
    {
        ca = xPai + pos.x;
        co = yPai + pos.y; 
        tg = co/ca;
        deg = Mathf.Rad2Deg * Mathf.Atan(tg);
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.white; 
        Gizmos.DrawWireSphere(pos,.3f);
    }
}
