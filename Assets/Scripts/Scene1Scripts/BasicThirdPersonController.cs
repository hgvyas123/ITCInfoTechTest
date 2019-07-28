using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicThirdPersonController : MonoBehaviour
{
    [SerializeField] Rigidbody mRigidbody;
    [SerializeField] float mMoveSpeed, mRotateSpeed, mJumpPower;
    Vector2 mUserInput = Vector2.zero;
    bool mCanJump = false;

    public void ApplyUserInput(float horizontal,float vertical)
    {
        mUserInput = new Vector2(horizontal, vertical);
    }

    public void ApplyJump()
    {
        mCanJump = true;
    }

    void Update()
    {
        if (mCanJump)
        {
            if(Mathf.Abs(transform.position.y) <= 1.1f)
                mRigidbody.velocity = new Vector3(mRigidbody.velocity.x, mJumpPower, mRigidbody.velocity.z);
            mCanJump = false;
        }

        if(mUserInput.y > 0 )
        {
            Vector3 velocity = transform.forward * mMoveSpeed;
            mRigidbody.velocity = new Vector3(velocity.x, mRigidbody.velocity.y, velocity.z);
        }
        
        if(mUserInput.x != 0)
            transform.Rotate(0, mRotateSpeed * Time.deltaTime * mUserInput.x, 0);    
    }
}
