using GrpcClient_PI_21_01.Controllers;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class ActApp
    {

        public int ActAppNumber { get; set; }
        [Filterable("act_id")]
        public Act Act { get; set; }
        [Filterable("catch_request_id")]
        public App Application { get; set; }


        [Filterable("count_dogs")]
        public int CountDogs { get; set; }


        [Filterable("count_cats")]
        public int CountCats { get; set; }

        public ActApp(int actAppNumber, Act act, App application, int countDogs, int countCats)
        {
            ActAppNumber = actAppNumber;
            Act = act;
            Application = application;
            CountDogs = countDogs;
            CountCats = countCats;

        }

        public ActAppReply ToReply()
        {
            return new ActAppReply()
            {
                Act = Act.ToReply(),
                Actor = UserService.CurrentUser?.ToReply(),
                App = Application.ToReply(),
                Id = ActAppNumber,
                CountCats = CountCats,
                CountDogs = CountDogs,
            };
        }
    }
}
