namespace Firm
{
    public abstract class StaffMember
    {
        private string _name;
        private string _address;
        private string _phone;

        //-----------------------------------------------------------------
        // Sets up a staff member using the specified information.
        //-----------------------------------------------------------------
        protected StaffMember(string eName, string eAddress, string ePhone) 
        {
            _name = eName;
            _address = eAddress;
            _phone = ePhone;
        }

        //-----------------------------------------------------------------
        // Returns a string including the basic employee information.
        //-----------------------------------------------------------------
        public override string ToString() 
        {
            var result = "Name: " + _name + "\n";
            result += "Address: " + _address + "\n";
            result += "Phone: " + _phone;
            return result;
        }

        //-----------------------------------------------------------------
        // Derived classes must define the pay method for each type of
        // employee.
        //-----------------------------------------------------------------
        public abstract double Pay();
    }
}