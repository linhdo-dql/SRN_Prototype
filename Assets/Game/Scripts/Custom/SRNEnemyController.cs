using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNEnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private Animator mainCharacterAnimator;
    private static readonly int ClosedUpPlayer = Animator.StringToHash("ClosedUpPlayer");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Atk = Animator.StringToHash("Atk");

    private void Start()
    {
        mainCharacterAnimator = LevelManager.Current.Players[0].CharacterAnimator;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemyAnimator.SetBool(Idle, true);
            enemyAnimator.SetBool(Walking, false);
            enemyAnimator.SetBool(ClosedUpPlayer, false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAnimator.SetBool(Idle, true);
            enemyAnimator.SetBool(Walking, true);
            enemyAnimator.SetBool(ClosedUpPlayer, false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        float mainPosX = mainCharacterAnimator.gameObject.transform.localPosition.x;
        float enemyPosX = gameObject.transform.localPosition.x;
        if (col.CompareTag("Player"))
        {
            if (mainCharacterAnimator.gameObject.transform.localScale.x * gameObject.transform.localScale.x >= 0)
            {
                enemyAnimator.SetBool(ClosedUpPlayer, true);
            }
            else
            {
                enemyAnimator.SetBool(ClosedUpPlayer, mainCharacterAnimator.GetInteger(Atk) == 0 && mainCharacterAnimator.GetBool((Idle)));
            }
        }
    }

    private void Update()
    {
        /*if(aiWalk.i)*/
    }
}
