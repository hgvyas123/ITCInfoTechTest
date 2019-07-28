using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape2Ctrl : MonoBehaviour {

    public float scrollSpeed = -0.5f;
    public Animator m_Anim;

    private float cycleTime;
    private float tmpTime;
    private float deltaTime;
    
    // Use this for initialization
    void Start () {
        cycleTime = m_Anim.GetCurrentAnimatorStateInfo(0).length;
        tmpTime = cycleTime;
        deltaTime = 0f;
	}
	
	// Update is called once per frame
	public void UpdateMe () {
        deltaTime += Time.deltaTime;

        if(deltaTime >= tmpTime)
        {
            tmpTime += cycleTime;
        }

        if((tmpTime - cycleTime) <= deltaTime && deltaTime  < (tmpTime - cycleTime * 0.6f))
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
        }
        else if (deltaTime >= (tmpTime - cycleTime * 0.6f) && deltaTime <= (tmpTime - cycleTime * 0.3f))
        {
            
            float offset = Time.time * scrollSpeed;
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        }
        else if (deltaTime >= (tmpTime - cycleTime * 0.3f) && deltaTime <= tmpTime)
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
        }
        
	}
}
