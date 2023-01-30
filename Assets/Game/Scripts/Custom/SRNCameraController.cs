using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNCameraController : MonoBehaviour
{
    private CameraController cameraController;

    private void Start()
    {
        cameraController = gameObject.GetComponent<CameraController>();
    }

    private void Update()
    {
        cameraController.FollowsPlayer = LevelManager.Current.Players[0].transform.localPosition.x < 7;
    }
}
