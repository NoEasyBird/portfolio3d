using UnityEngine;
using Utility;

namespace InGame
{
    public class SpaceBackGround : BackGround
    {
        public ParticleSystem spaceEffect;

        public ParticleSystem makeAsset;

        private Material spaceMat;

        public override void Init()
        {
            base.Init();

            if (spaceMat == null)
            {
                spaceMat = "Material/SpaceSkyBox".LoadAsset<Material>();
            }

            if (spaceMat != null)
            {
                RenderSettings.skybox = spaceMat;
            }
            
            spaceEffect.Play(true);
            makeAsset.Stop(true);
        }
    }
}