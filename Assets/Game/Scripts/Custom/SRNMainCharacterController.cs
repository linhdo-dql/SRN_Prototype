using System.Collections;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Spine.Unity;
using UnityEngine;

public class SRNMainCharacterController : MonoBehaviour
{
    [SerializeField] private SkeletonMecanim _mecanim;
    private bool isAttacking = true;
    private CapsuleCollider2D _capsuleCollider2D;

    private static readonly int Death = Animator.StringToHash("Death");

    // Start is called before the first frame update
    void Start()
    {
        _capsuleCollider2D = GetComponents<CapsuleCollider2D>()[1];
        LevelManager.Instance.Players[0].CharacterHealth.CurrentHealth = 100;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyWeapon"))
        {
            Character enemy = other.GetComponent<SRNEnemyWeapon>().enemyCharacter;
            if(enemy.CharacterAnimator.GetBool(Death)) return;
            if (enemy.CharacterBrain.CurrentState.StateName
                .Equals("Shoot"))
            {
                StartCoroutine(MainAttacked(other.GetComponent<SRNEnemyWeapon>().DamageBase,0.6667f));
            }
           
        }
    }

    private IEnumerator MainAttacked(float damage, float time)
    {
        yield return new WaitForSeconds(time);
        LevelManager.Instance.Players[0].CharacterHealth.Damage(damage,gameObject,0.5f,0.5f,Vector2.up);
    }
}
