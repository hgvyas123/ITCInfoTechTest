using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    [SerializeField] Animator mAnimator;
    [SerializeField] float mMaxMachineSpeed = 3.0f;
    //In Seconds
    [SerializeField] float mTimeAtWhichMachineAtMaxSpeed = 5.0f;
    [SerializeField] Tape2Ctrl[] mArrTape2Ctrl;
    //To cache initial speed of each tape as it is set by inspector and one can specify different value for each tape which i dont wanted to waste
    Dictionary<Tape2Ctrl, float> mDictTape2CtrlSpeedMap = new Dictionary<Tape2Ctrl, float>();

    //States of our machine
    enum MachineState { MachineStarted, MachineRunning , MachineStopped, MachineNotRunning }
    MachineState mMachineState = MachineState.MachineNotRunning;
    
    void Awake()
    {
        mMachineState = MachineState.MachineNotRunning;
        mAnimator.enabled = false;
        //as machine not running disablining animator and also setting speed to 0
        mAnimator.speed = 0;
        //dont want unity to call Update constantly even if i dont wanted that so disabling script
        enabled = false;
        CacheSpeedOfTape2Ctrl();
        SetSpeedForTape2Ctrl();
    }

    void CacheSpeedOfTape2Ctrl()
    {
        for (int i = 0; i < mArrTape2Ctrl.Length; i++)
        {
            mDictTape2CtrlSpeedMap.Add(mArrTape2Ctrl[i], mArrTape2Ctrl[i].scrollSpeed);
        }
    }

    //syncing tape speed with machine speed
    void SetSpeedForTape2Ctrl()
    {
        for(int i = 0; i < mArrTape2Ctrl.Length; i++)
        {
            mArrTape2Ctrl[i].scrollSpeed = mDictTape2CtrlSpeedMap[mArrTape2Ctrl[i]] * mAnimator.speed;
        }
    }

    void UpdateTape2Crtl()
    {
        for (int i = 0; i < mArrTape2Ctrl.Length; i++)
        {
            //Using custom update so i can control when to call and not
            mArrTape2Ctrl[i].UpdateMe();
        }
    }

    void Update()
    {
        switch (mMachineState)
        {
            case MachineState.MachineStarted:
                mAnimator.speed = Mathf.Clamp(mAnimator.speed + mMaxMachineSpeed * Time.deltaTime /mTimeAtWhichMachineAtMaxSpeed,0,mMaxMachineSpeed);
                if (mAnimator.speed == mMaxMachineSpeed)
                {
                    //machine reached at max speed so changing state to MachineRunning
                    mAnimator.speed = mMaxMachineSpeed;
                    mMachineState = MachineState.MachineRunning;
                }
                break;
            case MachineState.MachineRunning:
                //No need of Update function now
                enabled = false;
                break;
            case MachineState.MachineStopped:
                mAnimator.speed = Mathf.Clamp(mAnimator.speed - mMaxMachineSpeed * Time.deltaTime / mTimeAtWhichMachineAtMaxSpeed, 0, mMaxMachineSpeed);
                if (mAnimator.speed == 0)
                {
                    ////machine stopped fully so changing state to MachineNotRunning
                    mAnimator.speed = 0;
                    mMachineState = MachineState.MachineNotRunning;
                }
                break;
            case MachineState.MachineNotRunning:
                //No need of Update function now
                enabled = false;
                break;
        }
        SetSpeedForTape2Ctrl();
        UpdateTape2Crtl();
    }

    public void StartMachine()
    {
        //setting machined to started state and enabling script so we can run Update
        mMachineState = MachineState.MachineStarted;
        //enabling so Update can run
        mAnimator.enabled = true;
        mAnimator.speed = 0;
        enabled = true;
    }

    public void StopMachine()
    {
        //setting machined to stopped state and enabling script so we can run Update
        mMachineState = MachineState.MachineStopped;
        //enabling so Update can run
        enabled = true;
    }
}
