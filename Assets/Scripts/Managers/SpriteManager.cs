using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SpriteManager
    {
        public SpriteRenderer SpriteRender { get; private set; }
        public IHasSprite Data { get; private set; }

        public SpriteManager(SpriteRenderer spriteRender, IHasSprite data)
        {
            SpriteRender = spriteRender;
            Data = data;
        }

        public void SetSprite()
        {
            SpriteRender.sprite = Data.Sprite;
        }
    }
}