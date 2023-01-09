using System.Collections.Generic;

namespace Game.Scripts.DataModel
{
    public class StageMapModel
    {
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Chapter
        {
            get => _chapter;
            set => _chapter = value;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public StageMapModeEnum Mode
        {
            get => _mode;
            set => _mode = value;
        }

        public float Time
        {
            get => _time;
            set => _time = value;
        }

        public BossModel.BossTypeEnum BossType
        {
            get => _bossType;
            set => _bossType = value;
        }

        public List<BoosterModel> Boosters
        {
            get => _boosters;
            set => _boosters = value;
        }

        public List<EnemyModel> Enemies
        {
            get => _enemies;
            set => _enemies = value;
        }

        public bool IsLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }

        public StageMapModel(string id, string name, int chapter, int level, StageMapModeEnum mode, float time,
            BossModel.BossTypeEnum bossType, List<BoosterModel> boosters, List<EnemyModel> enemies, bool isLocked)
        {
            _id = id;
            _name = name;
            _chapter = chapter;
            _level = level;
            _mode = mode;
            _time = time;
            _bossType = bossType;
            _boosters = boosters;
            _enemies = enemies;
            _isLocked = isLocked;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public enum StageMapModeEnum
        {
            Easy,
            Normal,
            Hard,
            Hell
        }
        
        private string _id;
        private string _name;
        private int _chapter;
        private int _level;
        private StageMapModeEnum _mode;
        private float _time;
        private BossModel.BossTypeEnum _bossType;
        private List<BoosterModel> _boosters;
        private List<EnemyModel> _enemies;
        private bool _isLocked;
    }
}