using UnityEngine;

class PCRenderer : MonoBehaviour {
    private PC pc;
    private SpriteRenderer pcSprite;

    private Sprite standImage;
    private Sprite jumpImage;

    private void Start()
    {
        pc = GetComponent<PC>();
        pcSprite = GetComponent<SpriteRenderer>();

        standImage = Resources.Load<Sprite>("Carp/Carp_stand");
        jumpImage = Resources.Load<Sprite>("Carp/Carp_jump");
    }

    private void Update()
    {
        if (pc.transform.localPosition.y <= 0) {
            SetImage(standImage);
        }
        else if (pc.GetActionType() == typeof(PCActionJump)) {
            SetImage(jumpImage);
        }
    }

    private void SetImage(Sprite sprite)
    {
        pcSprite.sprite = sprite;
    }
}