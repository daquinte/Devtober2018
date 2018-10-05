using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMaker : MonoBehaviour {

    public GameObject InkPrefab;            //Prefab de tinta
    public GameObject InkFather;            //Objeto del editor que contiene toda la tinta

    public Texture2D Brush;                 //Cursor con forma de pincel!
    void Start()
    {
        //Cursor.SetCursor(Brush, Vector2.zero, CursorMode.Auto);
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton(0))
        {
            Pinta();
        }

        else if (Input.GetMouseButton(1))
        {
            Borra();
        }

    }

    //Pinta una unidad de tinta, siempre que esté en una posicion vacia en el mapa
    public void Pinta()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider == null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;   //2D
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0;
            Instantiate(InkPrefab, objectPos, Quaternion.identity);
        }   
    }

    public void Borra()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Ink")
        {
            Destroy(hit.collider.gameObject);           
        }
    }
   
}
