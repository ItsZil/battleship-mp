namespace SharedLibrary.Interpreter
{
    public interface IExpression
    {
        List<string> Interpret(List<string> args);
    }
}
