using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] GameObject crosshairRef;
    public GameObject CrosshairReference { get; private set; }

    public void Initialize(float range, Sprite crossHairSprite = null)
    {
        if (crosshairRef)
        {
            CrosshairReference = crosshairRef;

            if (crossHairSprite)
            {
                CrosshairReference.GetComponentInChildren<SpriteRenderer>().sprite = crossHairSprite;
            }

            CrosshairReference.transform.position = new Vector2(range + transform.localScale.x, CrosshairReference.transform.position.y);
        } else
        {
            Debug.LogError($"ERROR: Missing reference to Crosshair object in {gameObject.name}");
        }
    }
}