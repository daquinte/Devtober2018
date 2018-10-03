
using UnityEngine;

public class Rope : MonoBehaviour {

    public Rigidbody2D hook;

    public Weight weight;

    public GameObject linkPrefab;

    private bool broken;

    public int links = 7;

	// Use this for initialization
	void Start () {
        GenerateRope();
	}

    //Loop for each link and create it
    //Tiene que tener un Line Renderer de alguna manera para que quede bien.
    void GenerateRope()
    {
        Rigidbody2D prevRB = hook;

        for(int i = 0; i < links; i++)
        {
            //transform == parents transform.
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = prevRB;

            if (i < links - 1)
            {
                //Ahora el RB previo al siguiente es el actual
                prevRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                //Le paso el RB del último link
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }


    void Update()
    { 
        
    }
}
