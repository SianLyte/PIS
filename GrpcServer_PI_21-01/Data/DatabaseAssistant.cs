namespace GrpcServer_PI_21_01.Data
{
    public class DatabaseAssistant
    {
        static DatabaseAssistant()
        {
            string password = "123";
            if (OperatingSystem.IsWindows())
            {
                var name = Environment.UserName;
                if (name == "tikho")
                    password = "P@ssw0rd";
            }
            ConnectionString = "Host=localhost;Username=postgres;Password=" + password + ";Database=animal_capture;";
        }

        public static readonly string ConnectionString = "Host=localhost;Username=postgres;Password=" +
            //"P@ssw0rd" +
            "123" +
            ";Database=animal_capture;";
    }
}
