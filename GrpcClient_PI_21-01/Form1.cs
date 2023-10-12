using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient_PI_21_01;

namespace GrpcClient_PI_21_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static async Task Connect()
        {
            // The port number must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            MessageBox.Show("Greeting: " + reply.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(Connect);
        }
    }
}