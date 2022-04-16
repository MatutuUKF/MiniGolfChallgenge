using UnityEngine;

public class BallScript : MonoBehaviour
{

   

    [SerializeField] float gravity;
    public bool turnOffBouncess = false;


    private LineRenderer lr;
    public Transform Pivot;

    Rigidbody rb;

    Vector3 lastVelocity;

    
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        Pivot = transform.Find("Pivot");
        rb = GetComponent<Rigidbody>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        

        lastVelocity = rb.velocity;

        // Sipka, jej smer, rotacia (smer lopticky)
       // Pivot.transform.eulerAngles = new Vector3(0, PivotRotationY, 0);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, Pivot.position);
        
        

    }
    
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    // Odrazanie lopty v spravnom smere od stien ked nastane koliza
    private void OnCollisionEnter(Collision collision)
    {
        if (!turnOffBouncess)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * (Mathf.Max(speed, 0f)) / 1.2f;
          
            
        }
    }

}

   
