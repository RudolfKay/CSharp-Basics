using System;

namespace Firm
{
    public class Employee : StaffMember
    {
        private string _socialSecurityNumber;
        protected double _payRate;

        //-----------------------------------------------------------------
        // Sets up an employee with the specified information.
        //-----------------------------------------------------------------
        public Employee(string eName, string eAddress, string ePhone,
            string socSecNumber, double rate) : base(eName, eAddress, ePhone)
        {
            _socialSecurityNumber = socSecNumber;
            _payRate = rate;
        }

        //-----------------------------------------------------------------
        // Returns information about an employee as a string.
        //-----------------------------------------------------------------
         public override string ToString() 
        {
             var result = base.ToString();
             result += "\nSocial Security Number: " + _socialSecurityNumber;

             return result;
         }

        //-----------------------------------------------------------------
        // Returns the pay rate for this employee.
        //-----------------------------------------------------------------
        public override double Pay()
        {
            return _payRate;
        }
    }
}