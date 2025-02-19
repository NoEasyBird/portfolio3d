using UnityEngine;

namespace InGame
{
    public class SpaceBackGround : BackGround
    {
        public ParticleSystem spaceEffect;

        public ParticleSystem makeAsset;

        public override void Init()
        {
            base.Init();
            spaceEffect.Play(true);
            makeAsset.Stop(true);
        }
    }
}