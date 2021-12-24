namespace Ghana.Services.DivisionsAPI.Commands

{
    public class RegionAdditionCommand : AdditionCommand
    {
        public RegionAdditionCommand(string regionCode)
        {
            DivisionCode = regionCode;
        }
    }
}
