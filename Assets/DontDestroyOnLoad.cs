using UnityEngine;

/// <summary>
/// Este componente permite que el objeto se mantenga en cambios de escenas
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

}
