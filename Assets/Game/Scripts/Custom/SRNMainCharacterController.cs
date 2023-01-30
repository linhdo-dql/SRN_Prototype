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
    // Start is called before the first frame update
    void Start()
    {
        _capsuleCollider2D = GetComponents<CapsuleCollider2D>()[1];
        LevelManager.Instance.Players[0].CharacterHealth.CurrentHealth = 100;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyWeapon") && isAttacking)
        {
            isAttacking = false;
            print("Bi danh");
           
            LevelManager.Instance.Players[0].CharacterHealth.Damage(1f,gameObject,0.5f,0.5f,Vector2.up);
            
            StartCoroutine(ResetAttackedState(1f));
        }
    }

    private IEnumerator ResetAttackedState(float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = true;
    }
}
