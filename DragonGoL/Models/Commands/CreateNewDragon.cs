namespace DragonGoL.Models.Commands
{
    /// <summary>
    /// Console command used to create a new dragon.
    /// </summary>
    public class CreateNewDragon
    {
        /// <summary>
        /// Console command containing a reference to the new dragon actor.
        /// </summary>
        /// <param name="dragonRef">A dragon actor reference.</param>
        public CreateNewDragon(Akka.Actor.IActorRef dragonRef)
        {
            Dragon = dragonRef;
        }

        public Akka.Actor.IActorRef Dragon { get; }
    }
}
