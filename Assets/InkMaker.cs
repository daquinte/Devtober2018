using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMaker : MonoBehaviour {

    public GameObject InkPrefab;            //Prefab de tinta

    public Texture2D Brush;                 //Cursor con forma de pincel!
    void Start()
    {
        //Cursor.SetCursor(Brush, Vector2.zero, CursorMode.Auto);
    }
    // Update is called once per frame
    void Update () {
        Debug.Log("UPDATE INKMAKER");

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed");
            //StartCoroutine("Pinta");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Instantiate(InkPrefab, hit.transform);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse up");
            //StopCoroutine("Pinta");
        }
        
    }

    
    public IEnumerator Pinta()
    {
        //Rayo desde la camara al punto de impacto
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Instantiate(InkPrefab, hit.transform);
        yield return new WaitForSeconds(0.5f);
    }
}
