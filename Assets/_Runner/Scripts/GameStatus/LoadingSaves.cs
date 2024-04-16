using Zenject;

namespace GameStatus
{
    public class LoadingSaves : IInitializable
    {
        private readonly InteractingWithSaves _interactingWithSaves;

        public LoadingSaves(InteractingWithSaves interactingWithSaves)
        {
            _interactingWithSaves = interactingWithSaves;
        }
        
        public GameData GameData { get; private set; }

        public void Initialize()
        {
            GameData = (GameData)_interactingWithSaves.Load(new GameData());
        } 
    }
}