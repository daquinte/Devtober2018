using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Atributos

    public static GameManager instance = null;       //Instancia del manager de tinta

    public GameObject InkPrefab;                    //Prefab de tinta
    public GameObject InkFather;                    //Objeto del editor que contiene toda la tinta

    public float MaxInk;                            //Tinta de Inicio
    public float UsedInkPerDrop;                    //Tinta que añades a la actual al pintar
    private float InkAct;                           //Tinta actual

    public float MaxDel;                            //Cantidad maxima de borrado permitida
    public float DeletePercentage;                  //Cantidad de delete que sube al borrar
    private float DelAct;                           //Borrado actual

    public Image Ink;                               //Imagen del medidor de tinta
    public Image Delete;                            //Imagen del medidor de delete

    public Texture2D Brush;                         //Cursor con forma de pincel!
    #endregion

    void Start()
    {
        //Damos valor a la instancia
        if (instance == null)   instance = this;
        //Si existiera una ya, borramos esta.
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);

        Cursor.SetCursor(Brush, Vector2.zero, CursorMode.Auto);

        //Inicializamos variables 
        InkAct = MaxInk;
        DelAct = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {

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
        if (InkAct > 0.0f)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;   //2D
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.z = 0;
                Instantiate(InkPrefab, objectPos, Quaternion.identity);

                //Añadimos la tinta
                InkAct -= UsedInkPerDrop;
                Ink.fillAmount = InkAct / MaxInk;
            }
        }
    }

    public void Borra()
    {
        if (DelAct <= MaxDel)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Ink")
            {
                Destroy(hit.collider.gameObject);
                //Añadimos al borrado
                DelAct += DeletePercentage;
                Delete.fillAmount = DelAct / MaxDel;
            }
        }
    }

}
