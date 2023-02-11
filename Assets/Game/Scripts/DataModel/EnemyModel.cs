using System.Collections.Generic;
using Game.Scripts.DataModel;

public class EnemyModel : CharacterModel
{
    public enum EnemyTypeEnum
    {
        Lancer,
        Greatsword,
        Gunship
    }

    private EnemyTypeEnum _type;

    public EnemyTypeEnum EnemyType
    {
        get;
        set;
    }
    private float _delayTime;
    public float DelayTime { get; set; }
    private Turn _turn;
    public Turn Turn { get; set; }
    public EnemyModel(string id, string name, int level, Power power, List<OutfitModel> outfits,
        CharacterStateEnum characterState, List<WeaponModel> weapons, EnemyTypeEnum type) : base(id, name,
        level, power, outfits, characterState, weapons)
    {
        this._type = type;
    }
    
}