using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Spine.Unity;
using UnityEngine;

public class MyAttackButton : MonoBehaviour
{

    private int numberHit;
    private int oldNumberHit;
    private Character mainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        numberHit = 0;
        oldNumberHit = 0;
        mainCharacter = LevelManager.Current.Players[0];
    }

    public void ComboHit()
    {
        numberHit = numberHit + 1 < 4 ? numberHit + 1 : 0;
        /*mainCharacter.CharacterAnimator.*/
    }

    
}
