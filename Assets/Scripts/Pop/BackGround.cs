using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public float speedLep;


	// Use this for initialization
	void Start () {
	
	}

    void Move()
    {
        if (this.transform.localPosition.x >= 1500)
        {
            this.transform.localPosition = new Vector3(-1200, this.transform.localPosition.y, this.transform.localPosition.z);
        }
        this.transform.localPosition += new Vector3(speedLep, 0f, 0f);
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}
}
