using System;
using System.Collections;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

public class SRNEnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private Animator _mainCharacterAnimator;
    private static readonly int ClosedUpPlayer = Animator.StringToHash("ClosedUpPlayer");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Atk = Animator.StringToHash("Atk");
    private static readonly int Hit = Animator.StringToHash("Hit");
    [SerializeField] private Health mainHealth;
    public EnemyModel EnemyModel;
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void OnTriggerEnter2D(Collider2D col)
    {
        enemyAnimator.SetBool(Hit, false);
        enemyAnimator.SetBool(Idle, false);
        enemyAnimator.SetBool(Walking, false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAnimator.SetBool(Hit, false);
            enemyAnimator.SetBool(Idle, false);
            enemyAnimator.SetBool(Walking, false);
           
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {   
        if (col.CompareTag("Player"))
        {    
            if(enemyAnimator.GetBool(Death)) return;
            _mainCharacterAnimator = LevelManager.Current.Players[0].CharacterAnimator;
            enemyAnimator.SetBool(Walking, false);
            if (_mainCharacterAnimator.GetInteger(Atk) != 0)
            {   
                enemyAnimator.SetBool(Hit, true);
                mainHealth.Damage(10, gameObject,0.5f, 0.5f, Vector2.up);
            }
            else
            {
                    enemyAnimator.SetBool(Hit, false);
            }
        }
    }

    private void LateUpdate()
    {
         if (mainHealth.CurrentHealth == 0)
         {   
             enemyAnimator.SetBool(Death, true);
             enemyAnimator.SetBool(Walking, false);
             StartCoroutine(DestroyEnemy());
         }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    
    }

    private void Update()
    {
        
    }
}
