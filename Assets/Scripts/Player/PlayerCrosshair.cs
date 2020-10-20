using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] GameObject CrossHair;
#pragma warning restore CS0649

    public void Initialize(float range, Sprite crossHairSprite = null)
    {
        if (crossHairSprite)
        {
            // will have to test if we have to disable and reenable
            CrossHair.GetComponentInChildren<SpriteRenderer>().sprite = crossHairSprite;
        }

        CrossHair.transform.position = new Vector2(range + transform.localScale.x, CrossHair.transform.position.y);
    }
}