using System.Collections.Generic;
using Game.Scripts.Custom;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNCameraController : MonoBehaviour
{
    private CameraController cameraController;
    private Character _mainCharacter;
    public List<Transform> gates;
    private void Start()
    {
        cameraController = gameObject.GetComponent<CameraController>();
        
    }

    private void FixedUpdate()
    {   
        _mainCharacter = LevelManager.Current.Players[0];
        cameraController.FollowsPlayer = ((_mainCharacter.transform.position.x - gates[0].transform.position.x) > 10 && (gates[1].transform.position.x - _mainCharacter.transform.position.x) > 10) || SRNLevelManager.Instance.isClearTurn;
    }
}
