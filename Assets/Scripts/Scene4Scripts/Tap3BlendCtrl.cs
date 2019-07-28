using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap3BlendCtrl : MonoBehaviour {
    public Animator m_Anim;
    private float cycleTime;
    private float tmpTime;
    private float deltaTime;
    private float blendDeltaValue;
    private float blendVal;
    // Use this for initialization
    void Start()
    {
        cycleTime = m_Anim.GetCurrentAnimatorStateInfo(0).length;
        blendVal = 0f;
        tmpTime = cycleTime;
        blendDeltaValue = cycleTime * 0.3f * 100f;
        deltaTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime >= tmpTime)
        {
            tmpTime += cycleTime;
        }

        if ((tmpTime - cycleTime) <= deltaTime && deltaTime < (tmpTime - cycleTime * 0.6f))
        {
            blendVal += 3.4f;
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, blendVal);
        }
        else if (deltaTime >= (tmpTime - cycleTime * 0.6f) && deltaTime <= (tmpTime - cycleTime * 0.3f))
        {
            blendVal -= 9f;
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, blendVal);
        }
        else if (deltaTime >= (tmpTime - cycleTime * 0.3f) && deltaTime <= tmpTime)
        {
            blendVal = 0f;
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, blendVal);
        }
    }
}
