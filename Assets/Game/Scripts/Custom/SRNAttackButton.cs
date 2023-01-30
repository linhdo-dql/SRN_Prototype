using System;
using System.Collections;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNAttackButton : MonoBehaviour
{
    public static float AttackSkillCooldown = 0.5333f;
    private int _numberHit;
    private Character _mainCharacter;
    private DateTime _startSkillTime;
    private DateTime _startJumpAttackSkill;
    private Coroutine _normalCoroutine;
    private static readonly int JumpAtk = Animator.StringToHash("JumpAtk");
    private static readonly int Atk = Animator.StringToHash("Atk");

    // Start is called before the first frame update
    void Start()
    {
        _numberHit = 0;
        _mainCharacter = LevelManager.Current.Players[0];
        _startSkillTime = DateTime.MinValue;
    }

    public void ComboHit()
    {
        var timeSpan = DateTime.Now - _startSkillTime;
        var jumpTimeSpan = DateTime.Now - _startJumpAttackSkill;
        if (jumpTimeSpan.TotalSeconds < 1f)
        {
            _mainCharacter.CharacterAnimator.SetBool(JumpAtk, true);
        }
        if (timeSpan.TotalSeconds < AttackSkillCooldown)
        {   
            return;
        }
        if (timeSpan.TotalSeconds > 1f)
        {
            _numberHit = 1;
        }
        else
        {
            _numberHit = _numberHit + 1 < 4 ? _numberHit + 1 : 1;
        }
        _startSkillTime = DateTime.Now;
        _mainCharacter.CharacterAnimator.SetInteger(Atk, _numberHit);
        _normalCoroutine = StartCoroutine(IENormalizeCharacter());

    }

    private IEnumerator IENormalizeCharacter()
    {
        yield return new WaitForSeconds(AttackSkillCooldown);
        _mainCharacter.CharacterAnimator.SetInteger(Atk, 0);
    }

    public void SetStartJumpAttackSkill()
    {
       _startJumpAttackSkill = DateTime.Now;
        _mainCharacter.CharacterAnimator.SetBool("JumpAtk", false);
    } 
}
