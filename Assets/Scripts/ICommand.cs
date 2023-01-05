namespace HeartAttackGames.DesignPatterns.Command
{
    public interface ICommand
    { 
        public void Execute();

        public bool IsFinished();
    }
}
