namespace SharedLibrary.Interpreter
{
    public class PlaceShipExpression : IExpression
    {
        public List<string> Interpret(List<string> args)
        {
            args[0] = (int.TryParse(args[0], out int x) ? x : -1).ToString();
            args[1] = (int.TryParse(args[1], out int y) ? y : -1).ToString();
            return args;
        }
    }
}
