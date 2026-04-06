using Kursovaya.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        //Поле хранения текущего пользователя
        public static User currentUser;

        public static KursovayaEntities context = new KursovayaEntities();
    }
}
