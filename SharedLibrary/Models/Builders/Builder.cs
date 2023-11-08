namespace SharedLibrary.Models.Builders
{
    public abstract class Builder<T, G>
    {
        public abstract G Build(string clientId);
        public abstract T Get();
    }
}
