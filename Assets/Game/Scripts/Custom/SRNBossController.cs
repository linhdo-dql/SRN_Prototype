using Spine;
using Spine.Unity;
using Spine.Unity.Examples;
using UnityEngine;

public class SRNBossController : MonoBehaviour
{
    public SkeletonMecanim model;

    private Slot _swordRight;

    [SerializeField] private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        _swordRight = model.Skeleton.Slots.Find(s => s.Attachment.Name == "sword_R");
        RegionAttachment newAttachment = model.skeleton.AttachUnitySprite("sword_R", sprite) as RegionAttachment;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = _swordRight.Bone.GetWorldPosition(model.transform);
        RegionAttachment original = _swordRight.Attachment as RegionAttachment;
        print(v);
    }
}
