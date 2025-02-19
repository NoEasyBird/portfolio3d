
namespace Utility
{
    public class MonoSingleton<T> : CallBackMonoBehaviour where T : CallBackMonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = typeof(T).GetPath().LoadPrefab<T>();
                }

                return instance;
            }
        }

        public bool dontDestroyOnLoad;

        protected override void Awake()
        {
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            base.Awake();
        }
    }
}