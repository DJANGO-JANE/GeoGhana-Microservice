namespace Ghana.Services.DivisionsAPI.Commands
{
    public class LocalityAdditionCommand :AdditionCommand
    {
        public LocalityAdditionCommand(string localityCode)
        {
            DivisionCode = localityCode;
        }
    }
}
