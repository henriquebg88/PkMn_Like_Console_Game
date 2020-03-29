namespace Game
{
    class Toxin : Attack
    {
        public Toxin()
        {
            Name = "Toxin";
            Power = 0;
            StaminaCost = 30;
            Constancy = 1;
            Effect = new Poison();
        }
    }
}