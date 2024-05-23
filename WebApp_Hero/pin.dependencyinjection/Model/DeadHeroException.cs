
namespace pin.dependencyinjection.Model
{
    public class DeadHeroException : Exception
    {
        public DeadHeroException() : base()
        {
        }

        public DeadHeroException(string message) : base(message)
        {
        }

        public DeadHeroException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
