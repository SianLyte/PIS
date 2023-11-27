using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcClient_PI_21_01.Views
{
    public partial class HistoryForm : Form
    {
        private int _i = 0;
        // нужно чтобы работало оно:
        public HistoryForm(List<OperationReply> data)
        {
            InitializeComponent();
            ParceData(data);
        }

        // а вот это убрать:
        public HistoryForm(List<string> oldFormatData)
        {
            InitializeComponent();
            ParceData(oldFormatData);
        }

        // подсказка: чтобы посмотреть какие есть свойства у OperationReply, просто напиши data[0].
        // и Visual Studio сам подскажет какие существуют, удачи!
        private void ParceData(List<string> data)
        {
            surnameTextBox.Text = data[0].ToString();
            nameTextBox.Text = data[1].ToString();
            patronymicTextBox.Text = data[2].ToString();
            //numberTextBox.Text = data[3].ToString(); // убрать: у нас в лабах нет поля телефон у пользователя
            //mailTextBox.Text = data[4].ToString(); // убрать: у нас в лабах нет поля почта у пользователя
            OrganisationTextBox.Text = data[5].ToString();
            //nameStructureTextBox.Text = data[6].ToString(); // убрать: такого поля у организации нет
            postTextBox.Text = data[7].ToString();
            //trueNumberTextBox.Text = data[8].ToString(); // убрать: нет и не надо такого поля у юзера
            //trueMailTextBox.Text = data[9].ToString(); // убрать: нет и не надо такого поля у юзера
            loginTextBox.Text = data[10].ToString();
            dateTimeTextBox.Text = data[11].ToString();
            objectNumberTextBox.Text = data[12].ToString();
            descriptionTextBox.Text = data[13].ToString(); // подкорректировать: замени на "вид действия"
                                                           // и используй operation.ActionType
            nameTableBox.Text = data[14].ToString(); // убрать: файлы мы не загружаем в нашей системе
            // добавить: наименование таблицы, в которой произошло изменение
        }

        private void ParceData(List<OperationReply> data)
        {
            MessageBox.Show(data[_i].ModifiedTableName);
            //surnameTextBox.Text = data[0].ToString();
            //nameTextBox.Text = data[1].ToString();
            //patronymicTextBox.Text = data[2].ToString();
            //OrganisationTextBox.Text = data[5].ToString();
            //postTextBox.Text = data[7].ToString();
            //loginTextBox.Text = data[10].ToString();
            //dateTimeTextBox.Text = data[11].ToString();
            //objectNumberTextBox.Text = data[12].ToString();
            //descriptionTextBox.Text = data[13].ToString(); 
            //                                               // и используй operation.ActionType
            //nameTableBox.Text = data[14].ToString(); 
        }
    }
}
