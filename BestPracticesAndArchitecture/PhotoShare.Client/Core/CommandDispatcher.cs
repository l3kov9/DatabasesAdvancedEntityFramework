namespace PhotoShare.Client.Core
{
    using PhotoShare.Client.Core.Commands;
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var command = commandParameters[0].ToLower();

            var result = string.Empty;

            switch (command)
            {
                case "registeruser": result = RegisterUserCommand.Execute(commandParameters);
                    break;
                case "addtown": result = AddTownCommand.Execute(commandParameters);
                    break;
                case "modifyuser": result = ModifyUserCommand.Execute(commandParameters);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
