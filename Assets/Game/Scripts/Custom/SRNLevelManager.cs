using System.Collections.Generic;
using Game.Scripts.DataModel;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Scripts.Custom
{
    public class SRNLevelManager : MonoBehaviour
    {
        public Transform levelStart;
        public Transform turn1Init;
        public Transform turn2Init;
        public Transform turn3Init;
        public Transform levelEnd;
        public GameObject parentEnemiesGo;
        public GameObject enemyPrefab;

        private void Start()
        {
           // InitEnemies(FakeListEnemy());
        }

        private void InitEnemies(List<EnemyModel> enemyModels)
        {
            foreach (EnemyModel enemyModel in enemyModels)
            {
                Populate(enemyModel);
            }
        }

        private void Populate(EnemyModel e)
        {
            Debug.Log(e.Turn);
            Instantiate(enemyPrefab, SetPosition(e.Turn), Quaternion.identity, parentEnemiesGo.transform);
            enemyPrefab.GetComponent<CharacterHorizontalMovement>().WalkSpeed = e.Power.SpeedMovement;
        }

        private Vector3 SetPosition(int turn)
        {
            var position = levelStart.transform.position - new Vector3(7, 0, 0);
            return turn switch
            {
                0 => position,
                1 => turn1Init.transform.position,
                2 => turn2Init.transform.position,
                3 => turn3Init.transform.position,
                4 => levelEnd.transform.position,
                _ => position
            };
        }

        private static List<EnemyModel> FakeListEnemy()
        {
            return new List<EnemyModel>
            {
                new EnemyModel("1", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 6},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 1},
                new EnemyModel("2", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 3},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 0},
                new EnemyModel("3", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 7},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 1},
                new EnemyModel("4", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 3},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 2},
                new EnemyModel("5", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 4},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 1},
                new EnemyModel("6", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 3},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 2},
                new EnemyModel("7", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 1},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 3},
                new EnemyModel("8", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 3},
            };
        }
    }
}