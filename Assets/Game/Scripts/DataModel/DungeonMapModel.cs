namespace Game.Scripts.DataModel
{
    public class DungeonMapModel
    {
        public DungeonMapModel(string id, string name, DungeonMapModeEnum mode, int enemyCount, float time, int gold,
            bool isLocked)
        {
            this._id = id;
            this._name = name;
            this._mode = mode;
            this._enemyCount = enemyCount;
            this._time = time;
            this._gold = gold;
            this._isLocked = isLocked;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DungeonMapModeEnum Mode
        {
            get => _mode;
            set => _mode = value;
        }

        public int EnemyCount
        {
            get => _enemyCount;
            set => _enemyCount = value;
        }

        public float Time
        {
            get => _time;
            set => _time = value;
        }

        public int Gold
        {
            get => _gold;
            set => _gold = value;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public bool IsLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }

        public enum DungeonMapModeEnum
        {
            Easy,
            Normal,
            Hard,
            Hell,
            Tower1,
            Tower2,
            Tower3
        }

        private string _id;
        private string _name;
        private DungeonMapModeEnum _mode;
        private int _enemyCount;
        private float _time;
        private int _gold;
        private bool _isLocked;
    }
}