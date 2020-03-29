namespace Game
{
    abstract class Attack
    {
        public string Name { get; protected set; }
        public int Power { get; protected set; }
        public int StaminaCost { get; protected set; }
        public int Constancy {get; protected set; }
        public Effect Effect {get; protected set; }
    }
}