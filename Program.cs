namespace ConnectionString;

class Program
{
    static void Main(string[] args)
    {
        Connection.Connect();
        DatabaseManager.CreateDB();
        DatabaseManager.SeedDB();

        //Data.Employee employee = new Data.Employee("Mathias", "Dumas", new DateTime (2024-03-19));
        //employee.Insert();
        //employee.Update(1, "Ploup");
        //employee.ReadAll();

        //Data.Pays pays1 = new Data.Pays("France");
        //pays1.Insert();
        //employee.DeleteById(1);

    }
}
