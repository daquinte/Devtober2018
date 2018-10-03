
using UnityEngine;

public class RopeCutter : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //Comprobamos si hay una parte de la cadena EN EL CLICK, no hay slice
        if (Input.GetMouseButtonDown(0))
        {
            //Rayo desde la camara al punto de impacto
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                if(hit.collider.tag == "Link")
                {
                    //A pastar
                    Destroy(hit.collider.gameObject);
                }
            }
        }
	}
}
