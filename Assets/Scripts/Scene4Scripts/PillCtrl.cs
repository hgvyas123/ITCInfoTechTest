using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillCtrl : MonoBehaviour {
    public float thrust;
    private bool isEnd;

    // Use this for initialization
    void Start () {
        isEnd = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(!isEnd)
            transform.Translate(-transform.right * Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckCol")
        {
            isEnd = true;
        }
    }
}
