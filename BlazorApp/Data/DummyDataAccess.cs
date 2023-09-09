namespace BlazorApp.Data;

public class DummyDataAccess : IDataAccess
{

    private int age;

    public DummyDataAccess()
    {
        Random rnd = new Random();
        age = rnd.Next(1, 5);

    }

    public int GetData()
    {
        return age;
    }
}
