using UnityEngine;

public partial class UserInputHandler : MonoBehaviour
{
#if UNITY_EDITOR || UNITY_STANDALONE
    const string horizontalAxis = "Horizontal";
    const string verticalAxis = "Vertical";

    void Update()
    {
        mBasicThirdPersonController.ApplyUserInput(Input.GetAxis(horizontalAxis),Input.GetAxis(verticalAxis));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mBasicThirdPersonController.ApplyJump();
        }
    }
#endif
}
