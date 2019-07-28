using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillGenerateCtrl : MonoBehaviour {
    public GameObject pillPrefab;
    public GameObject m_Parent;

    private float deltaTime;

    // Use this for initialization
	void Start () {
        deltaTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
		if(deltaTime > 2.5f)
        {
            GameObject obj = Instantiate(pillPrefab, m_Parent.transform) as GameObject;
            obj.transform.localPosition = new Vector3(0f, 0f, 0f);
            deltaTime = 0f;
        }
	}
}
