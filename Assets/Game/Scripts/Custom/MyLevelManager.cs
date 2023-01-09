using System;
using System.Collections.Generic;
using Game.Scripts.DataModel;
using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
            // InitEnemies(FakeListEnemy());
        }

        // public void InitEnemies(List<EnemyModel> enemyModels)
        // {
        //     foreach (EnemyModel enemyModel in enemyModels)
        //     {
        //         Populate(enemyModel);
        //     }
        // }

        // private void Populate(EnemyModel e)
        // {
        //     Instantiate(enemyPrefab,e.InitPosition, Quaternion.identity, parentEnemiesGo.transform);
        //     enemyPrefab.transform.position = e.InitPosition;
        //     enemyPrefab.GetComponent<CharacterHorizontalMovement>().WalkSpeed = e.Speed;
        // }

        // public List<EnemyModel> FakeListEnemy()
        // {
        //     List<EnemyModel> enemies = new List<EnemyModel>();
        //     var position = levelStart.position;
        //     var position1 = turn1Init.position;
        //     var position2 = turn2Init.position;
        //     var position3 = turn3Init.position;
        //     var position4 = levelEnd.position;
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 5});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 9});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 6});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 4});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 8});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 5});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,200, 50), InitPosition = position1, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 3});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,200, 50), InitPosition = position1, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 1});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,200, 50), InitPosition = position1, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 2});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,200, 50), InitPosition = position1, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 8});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,100, 50), InitPosition = position1, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 1});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,200, 50), InitPosition = position2, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 1});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position2, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 9});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position2, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 7});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position2, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 3});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position2, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 2});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position3, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 5});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position3, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 9});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position3, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 2});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position3, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 1}); 
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position3, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 3});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position4, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 5});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position4, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 4});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position4, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 5});
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position4, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 2}); 
        //     enemies.Add(new EnemyModel() {Power = new Power(1,300, 50), InitPosition = position4, StateOfEnemy = EnemyModel.EnemyState.Idle, TypeOfEnemy = EnemyModel.TypeEnemy.Greatsword, Speed = 1});
        //     return enemies;
        // }
    }
}