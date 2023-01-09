namespace Game.Scripts.DataModel
{
    public class OutfitModel
    {
        public OutfitModel()
        {
        }

        public OutfitModel(string id, string name, string position)
        {
            _id = id;
            _name = name;
            _position = position;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Position
        {
            get => _position;
            set => _position = value;
        }

        private string _id;
        private string _name;
        private string _position;
    }
}