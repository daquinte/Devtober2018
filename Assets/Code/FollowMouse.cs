using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MoveToMousePosition();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            MoveToMousePosition();
        }
    }

    private void MoveToMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;   //2D
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        objectPos.z = 0;  //Shit happens otherwise?

        transform.position = objectPos;
    }
}
