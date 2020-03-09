using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Employees
{
    [MessageNamespace("employees")]
    public class CreateEmployee : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string Surname { get; }
        public DateTime Birthday { get; }
        public EmployeeStatus EmployeeStatus { get; }
        public EmployeePosition EmployeePosition { get; }

        [JsonConstructor]
        public CreateEmployee(Guid id, string firstName, string secondName, string surname, 
            DateTime birthday, EmployeeStatus employeeStatus, EmployeePosition employeePosition)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            Birthday = birthday;
            EmployeeStatus = employeeStatus;
            EmployeePosition = employeePosition;
        }
    }
}