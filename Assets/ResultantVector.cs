using Unity.Mathematics;
using UnityEngine;

public class ResultantVector : MonoBehaviour
{
    [SerializeField] SpriteRenderer boundsY, boundsX;
    float moveY;
    float moveX;
    [SerializeField] Transform resultantArrow;
    public Vector2 pos;
    // Update is called once per frame
    float posX, posY;
    float tg, xPai, yPai, deg, _ca, _co;

    public float ca
    {
        get { return _ca; }
        set { _ca = value; }
    }
    public float co
    {
        get { return _co; }
        set { _co = value; }
    }
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
        
        if(!boundsX.enabled) pos.x = posX;
        if(!boundsY.enabled) pos.y = posY;
        if(!(pos.x == posX && pos.y == posY))
        {
            resultantArrow.eulerAngles = new Vector3(0,0,-(90-deg));
            resultantArrow.GetComponent<SpriteRenderer>().enabled = true;
        } 
        else resultantArrow.GetComponent<SpriteRenderer>().enabled = false;
        resultantArrow.transform.position = new Vector2(pos.x, pos.y);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        GetComponent<LineRenderer>().SetPosition(1,pos);
    }

    void calcTg()
    {
        if(!boundsX.enabled) ca = 0;
        else ca = xPai + pos.x;
        if(!boundsY.enabled) co = 0;
        else co = yPai + pos.y;

        tg = co/ca;
        deg = Mathf.Rad2Deg * Mathf.Atan(tg);
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.white; 
        Gizmos.DrawWireSphere(pos,.3f);
    }
}
