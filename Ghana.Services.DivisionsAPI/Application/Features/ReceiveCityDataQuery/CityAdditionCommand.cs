namespace Ghana.Services.DivisionsAPI.Commands

{

    public class CityAdditionCommand : AdditionCommand
    {
        public CityAdditionCommand(string cityCode)
        {
            DivisionCode = cityCode;
        }
    }
}
