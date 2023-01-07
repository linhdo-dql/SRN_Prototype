using System.Numerics;
using Game.Scripts.DataModel;
using Vector3 = UnityEngine.Vector3;

public class EnemyModel
{
    public enum TypeEnemy
    {
        Lancer,
        Greatsword,
        Gunship
    }
    
    public enum EnemyState
    {
        Idle,
        Run,
        Attack,
        Death
    }

    public Power Power { get; set; }
    
    public TypeEnemy TypeOfEnemy { get; set; }
    
    public EnemyState StateOfEnemy { get; set; }
    
    public Vector3 InitPosition { get; set; }
    public float Speed { get; set; }
}
