using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Spine.Unity;
using UnityEngine;

public class MyAttackButton : MonoBehaviour
{
    public static float AttackSkillCooldown = 0.5333f;
    private int numberHit;
    private int oldNumberHit;
    private Character mainCharacter;
    private DateTime _startSkillTime;
    private DateTime _startJumpAttackSkill;
    private Coroutine _normalCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        numberHit = 1;
        oldNumberHit = 0;
        mainCharacter = LevelManager.Current.Players[0];
        _startSkillTime = DateTime.MinValue;
       
    }

    public void ComboHit()
    {
        var timeSpan = DateTime.Now - _startSkillTime;

        var jumpTimeSpan = DateTime.Now - _startJumpAttackSkill;
     
        if (jumpTimeSpan.TotalSeconds < 2f)
        {
            mainCharacter.CharacterAnimator.SetBool("JumpAtk", true);
        }
      
        if (timeSpan.TotalSeconds < AttackSkillCooldown)
        {   
            return;
        }
        if (timeSpan.TotalSeconds > 1f)
        {
            numberHit = 1;
        }
        else
        {
            numberHit = numberHit < 3 ? numberHit + 1 : 1;
        }

        Debug.Log(numberHit);
        _startSkillTime = DateTime.Now;
        mainCharacter.CharacterAnimator.SetInteger("Atk", numberHit);
        _normalCoroutine = StartCoroutine(IENormalizeCharacter());

    }

    private IEnumerator IENormalizeCharacter()
    {
        yield return new WaitForSeconds(0.5333f);
        mainCharacter.CharacterAnimator.SetInteger("Atk", 0);
    }

    public void SetStartJumpAttackSkill()
    {
       _startJumpAttackSkill = DateTime.Now;
        mainCharacter.CharacterAnimator.SetBool("JumpAtk", false);
       
    } 
}
