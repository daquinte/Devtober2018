using UnityEngine;

public class Ball : MonoBehaviour {

    #region attributes
    public float velX;            //Velocidad constante a la que se mueve
    public float rot;           //Rotacion de la bola

    bool Avanzando = true;             //Determina si está avanzando o retrocediendo
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3((velX * Time.deltaTime), 0.0f, 0.0f);
        transform.Rotate(new Vector3(0,0, (-rot * Time.deltaTime)));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            velX = -velX;
            rot = -rot;
            Avanzando = !Avanzando;

        }

        else if (collision.gameObject.tag == "Meta")
        {
            Debug.Log("SUUUUUUUUUU");
        }
    }
}

