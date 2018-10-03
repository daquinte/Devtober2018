///
//Método que conecta un segundo objeto al final de una cadena
///

using UnityEngine;

public class Weight : MonoBehaviour {
    
    //Recibe el RB del ultimo elemento de la cadena
    public void ConnectRopeEnd (Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();

        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, 0f);
    }
	
}
