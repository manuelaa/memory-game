using UnityEngine;
using System.Collections;

public class TestButtonScript : MonoBehaviour {


    public float progress = 0;
    public float height = 5f;

    private Vector3 origin;
    private Vector3 origRot;
    private Vector3 flipRot;

    public GameObject go;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Rotate()
    {
        progress = Mathf.Clamp(progress, 0, 90);

        Vector3 pos = origin;
        pos.y = (Mathf.Sin(Mathf.Deg2Rad * progress) * Mathf.Cos(Mathf.Deg2Rad * progress) * height) + origin.y;

        go.transform.position = pos; // handle moving upwards
        go.transform.rotation = Quaternion.Lerp(Quaternion.Euler(origRot), Quaternion.Euler(flipRot), progress / 90); // handle rotation
    }

    public void FunctionWorks(string name)
    {
        Debug.Log(name);
    }

    public void FunctionDoesntWork(string first, string second)
    {

    }
}
