using System;

using WarCroft.Constants;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        protected Character()
        {
                
        }

        public string Name
        {
            get { return this.name;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentNullException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get;  set; }
		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}