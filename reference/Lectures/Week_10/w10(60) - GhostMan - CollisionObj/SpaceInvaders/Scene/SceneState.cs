
using System.Diagnostics;

namespace SE456
{
    public abstract class SceneState
    {
        public abstract void Handle();
        public abstract void Initialize();
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Transition();

    }
}

// --- End of File ---
