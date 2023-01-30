using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNEnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private Animator _mainCharacterAnimator;
    private static readonly int ClosedUpPlayer = Animator.StringToHash("ClosedUpPlayer");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Atk = Animator.StringToHash("Atk");
    private static readonly int Combo = Animator.StringToHash("Combo");
    private static readonly int Hit = Animator.StringToHash("Hit");

    private void Start()
    {
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
        _mainCharacterAnimator = LevelManager.Current.Players[0].CharacterAnimator;
        if (col.CompareTag("Player"))
        {
            if (_mainCharacterAnimator.gameObject.transform.localScale.x * gameObject.transform.localScale.x >= 0)
            {
                enemyAnimator.SetBool(ClosedUpPlayer, true);
            }
            else
            {
                enemyAnimator.SetBool(ClosedUpPlayer, _mainCharacterAnimator.GetInteger(Atk) == 0 && _mainCharacterAnimator.GetBool((Idle)));
            }
            if (_mainCharacterAnimator.GetInteger(Atk) != 0)
            {
                    enemyAnimator.SetBool(Combo, false);
                    enemyAnimator.SetBool(Hit, true);
            }
            else
            {
                    enemyAnimator.SetBool(Hit, false);
            }
        }
    }

    private void Update()
    {
        /*if(aiWalk.i)*/
    }
}
