using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.DataModel;
using MoreMountains.CorgiEngine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Scripts.Custom
{
    public class SRNLevelManager : MonoBehaviour
    {
        public static SRNLevelManager Instance;
        public Transform levelStart;
        public GameObject parentEnemiesGo;
        public List<GameObject> enemyPrefabs;
        public GameObject bossPrefab;
        public Character _mainCharacter;
        public List<Turn> listTurns;
        private int _currentTurn = 1;
        public int currentLevel;
        private float turnPositionStartEnemy;
        private bool _isAllTurnEnemy;
        private int _countEnemy;
        [SerializeField] private List<Transform> gates;
        [SerializeField] private List<Transform> initPoints;
        [SerializeField] private Image arrowRight;
        private List<GameObject> _enemies = new List<GameObject>();
        public bool isClearTurn;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _mainCharacter = LevelManager.Current.Players[0];
            InitLevel(currentLevel);
        }

        private void InitLevel(int currentLevel)
        {
            
        }

        public void InitTurn(int turn)
        {
            isClearTurn = false;
            InitGates(turn);
            gates.ForEach(g => g.gameObject.SetActive(true));
            InitEnemies(FakeListEnemy(), turn);
            if (_currentTurn == listTurns.Count - 1)
            {
                InitBoss();
            }
        }

        private void InitBoss()
        {
            var enemy =  Instantiate(bossPrefab, gates[1].position - new Vector3(2,0,0), Quaternion.identity, parentEnemiesGo.transform);
            EnemyModel swordBoss =new EnemyModel("1", "SwordBoss", 1, new Power() {AttackDamage = 10, Hp = 200}, new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),EnemyModel.EnemyTypeEnum.Greatsword);
            enemy.GetComponent<SRNEnemyController>().EnemyModel = swordBoss;
            enemy.GetComponent<Health>().CurrentHealth = swordBoss.Power.Hp;
        }

        private void InitGates(int turn)
        {
            gates[0].transform.position =  new Vector3(initPoints[turn - 1].position.x - 11, gates[0].transform.position.y, 0);
            gates[1].transform.position =  new Vector3(initPoints[turn - 1].position.x + 12, gates[0].transform.position.y, 0);
            LeanTween.alpha(gates[0].gameObject, 1, 1);
            LeanTween.alpha(gates[1].gameObject, 1, 1);
        }


        private void InitEnemies(List<EnemyModel> enemyModels, int turn)
        {
            _currentTurn = turn;
            for(int i = 0; i < FakeListEnemy().Count; i++)
            {
                StartCoroutine(Populate(FakeListEnemy()[i]));
            }
        }
         
        private void HideGate()
        {
            LeanTween.alpha(gates[0].gameObject, 0, 1);
            LeanTween.alpha(gates[1].gameObject, 0, 1);
        }

        private void NextTurn()
        {    
            _currentTurn++;
            isClearTurn = true;
            gates[0].gameObject.SetActive(false);
            gates[1].gameObject.SetActive(false);
            _isAllTurnEnemy = false;
            _countEnemy = 0;
            _enemies.ForEach(Destroy);
        }

        private void LateUpdate()
        {
            if (_isAllTurnEnemy)
            { 
                HideGate();
                var _enemiesInTurn = parentEnemiesGo.GetComponentsInChildren<SRNEnemyController>().ToList();
                if (_enemiesInTurn.Count <= 0 )
                {
                 
                    if (_currentTurn < initPoints.Count)
                    {
                        NextTurn();
                    }
                    else
                    {
                        InitBoss();
                    }
                }
            }
        }

        IEnumerator Populate(EnemyModel e)
        {
            yield return new WaitForSeconds(e.DelayTime);
            _countEnemy++;
            int enemyType = e.EnemyType switch
            {
                EnemyModel.EnemyTypeEnum.Greatsword => 0,
                EnemyModel.EnemyTypeEnum.Lancer => 1,
                _ => 2
            };
            var enemy = Instantiate(enemyPrefabs[enemyType], SetPosition(e.Turn.isLeft), Quaternion.identity, parentEnemiesGo.transform);
            _enemies.Add(enemy);
            enemy.GetComponent<SRNEnemyController>().EnemyModel = e;
            enemy.GetComponent<CharacterHorizontalMovement>().WalkSpeed = e.Power.SpeedMovement;
            enemy.GetComponent<Health>().CurrentHealth = e.Power.Hp;
            _isAllTurnEnemy = _countEnemy == FakeListEnemy().Count;
        }

        private Vector3 SetPosition(bool isLeft)
        {   
            Vector3 gatePosition = isLeft ? gates[0].position : gates[1].position;
            return gatePosition - new Vector3(isLeft? -1 : 1, 2, 0);
        }

        private static List<EnemyModel> FakeListEnemy()
        {
            return new List<EnemyModel>
            {
                new EnemyModel("1", "Swords Man", 1,
                    new Power() {Hp = 50, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Lancer){Turn = new Turn(){turnNumber = 1, isLeft = true}, DelayTime = 0},
                new EnemyModel("2", "Swords Man", 1, 
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = new Turn(){turnNumber = 1, isLeft = false}, DelayTime = 0},
                new EnemyModel("3", "Swords Man", 1, 
                    new Power() {Hp = 50, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Lancer){Turn = new Turn(){turnNumber = 1, isLeft = true}, DelayTime = 3},
                new EnemyModel("4", "Swords Man", 1, 
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = new Turn(){turnNumber = 1, isLeft = false}, DelayTime = 3},
                new EnemyModel("5", "Swords Man", 1,
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Lancer){Turn = new Turn(){turnNumber = 1, isLeft = true}, DelayTime = 7},
                new EnemyModel("6", "Swords Man", 1,
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Lancer){Turn = new Turn(){turnNumber = 1, isLeft = false}, DelayTime = 7},
                new EnemyModel("7", "Swords Man", 1,
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Greatsword){Turn = new Turn(){turnNumber = 1, isLeft = true}, DelayTime = 11},
                new EnemyModel("8", "Swords Man", 1,
                    new Power() {Hp = 100, Mp = 10, AttackDamage = 1, SpeedAttack = 10, SpeedMovement = 2},
                    new List<OutfitModel>(), CharacterStateEnum.Idle, new List<WeaponModel>(),
                    EnemyModel.EnemyTypeEnum.Lancer){Turn = new Turn(){turnNumber = 1, isLeft = false}, DelayTime = 11},
            };
        }
    }
}

[Serializable]
public class Turn
{   
    public int turnNumber { get; set; }
    public bool isLeft { get; set; }
    public Transform turnAreaLeft;
    public Transform turnAreaRight;
    public Vector3 TurnStartEnemy => new Vector3((turnAreaLeft.position.x + turnAreaRight.position.y) / 2,
        turnAreaLeft.position.y, turnAreaRight.position.z);
}