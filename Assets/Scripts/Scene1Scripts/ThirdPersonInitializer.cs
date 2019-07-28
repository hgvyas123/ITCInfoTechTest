using UnityEngine;

public class ThirdPersonInitializer : MonoBehaviour
{
    [SerializeField] BasicThirdPersonController mBasicThirdPersonController;
    [SerializeField] Camera mMainCamera;

    void Awake()
    {
        GameObject thirdPerson = Instantiate(mBasicThirdPersonController.gameObject,new Vector3(0,1,0),Quaternion.identity);
        mMainCamera.transform.parent = thirdPerson.transform;
    }
}
