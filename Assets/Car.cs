using UnityEngine;

public class Car : MonoBehaviour
{
    
    [SerializeField] float speedX, speedY;
    [SerializeField] ResultantVector forces;
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.position +=  Time.deltaTime * new Vector2(speedX, speedY);
    }

    void Update()
    {
        speedX = forces.ca;
        speedY = forces.co;
    }
}
