using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SRNEnemyWeapon : MonoBehaviour
{
    [SerializeField] public Character enemyCharacter;
    public float DamageBase;

    private void Start()
    {
        DamageBase = enemyCharacter.GetComponent<SRNEnemyController>().EnemyModel.Power.AttackDamage;
    }
}
