using System.Collections.Generic;
using Game.Scripts.DataModel;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Scripts.Custom
{
    public class MyLevelManager : MonoBehaviour
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
            InitEnemies(FakeListEnemy());
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
            enemyPrefab.transform.localPosition = SetPosition(e.Turn) ;
            enemyPrefab.GetComponent<CharacterHorizontalMovement>().WalkSpeed = e.Power.SpeedMovement;
        }

        private Vector3 SetPosition(int turn)
        {
            var position = levelStart.localPosition - new Vector3(9, 0, 0);
            switch (turn)
            {
                case 0: return position;
                case 1: return turn1Init.position;
                case 2: return turn2Init.position;
                case 3: return turn3Init.position;
                case 4: return levelEnd.position;
                default: return position;
            }
        }

        private List<EnemyModel> FakeListEnemy()
        {
            return new List<EnemyModel>
            {
                new EnemyModel("1", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 5},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 1},
                new EnemyModel("2", "Swords Man", 1,
                    new Power() {Hp = 10, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 3},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = 0},

            };
        }
    }
}