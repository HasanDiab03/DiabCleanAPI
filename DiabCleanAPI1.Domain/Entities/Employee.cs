namespace DiabCleanAPI
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string EmployeeCode { get; private set; }
        public Company? Company { get; private set; }

        public Employee(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            EmployeeCode = Guid.NewGuid().ToString();
        }

        public void Update(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}