using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {

	public float fuerzaSalto = 20f;
	public float fuerzaHorizontal = 1;
	public float maxVHorizontal;
	public float maxVVertical;
	public LayerMask mask;

    [HideInInspector]
	public bool suelo = false;

    Rigidbody rb;
    SphereCollider esfera;
    Vector2 velocidadHorizontal;
    float velocidadVertical;


	void Start () {
        rb = GetComponent<Rigidbody>();
        esfera = GetComponent<SphereCollider>();
        //mask = ~mask;
	}


	void FixedUpdate () {

        ClampVelocidad();
        CheckGround();
        //print(rb.velocity);
    }
    

    public void AddForce (Vector3 add)
	{
		rb.AddForce (add * rb.mass * fuerzaHorizontal);
	}


    public void Saltar()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        AddForce(Vector3.up * fuerzaSalto);
    }


    void ClampVelocidad()
    {
        velocidadHorizontal = new Vector2(rb.velocity.x, rb.velocity.z);
        velocidadHorizontal = Vector2.ClampMagnitude(velocidadHorizontal, maxVHorizontal);

        /*if (suelo) velocidadVertical = Mathf.Clamp(rb.velocity.y, 0, maxVVertical);
        else velocidadVertical=Mathf.Clamp(rb.velocity.y, -maxVVertical, maxVVertical);*/

        rb.velocity = new Vector3(velocidadHorizontal.x, Mathf.Clamp(rb.velocity.y, -maxVVertical, maxVVertical), velocidadHorizontal.y);
    }


    void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * (esfera.radius + 0.5f));

        if (Physics.Raycast(transform.position, Vector3.down, out hit, (esfera.radius + 0.5f), mask))
        {
            suelo = true;
            //print("EH QUE PUEDO SALTAR");
        }
        else
        {
            suelo = false;
        }
    }
}
