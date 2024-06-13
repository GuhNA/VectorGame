using UnityEngine;

public class ArrowControl : MonoBehaviour
{

    public float arrowSize;
    [SerializeField] bool UD;


    void Start()
    {
        arrowSize = .4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(UD) arrowUDLR(KeyCode.W, KeyCode.S);
        else arrowUDLR(KeyCode.D,KeyCode.A);
    }

    void arrowUDLR(KeyCode button1, KeyCode button2)
    {
        float timer = 0;
        if(Input.GetKey(button1)) timer += Time.deltaTime;
        else if(Input.GetKey(button2)) timer -= Time.deltaTime;
        else timer = 0;
        arrowSize = Mathf.Clamp(arrowSize + timer,-.4f,.4f);
        if(arrowSize > -.07f && arrowSize < .07f)
            transform.localScale = new Vector3(transform.localScale.x,0,transform.localScale.z);
        else transform.localScale = new Vector3(transform.localScale.x,arrowSize,transform.localScale.z);
    }

}
