using InformationSecurityConference.Data;
using InformationSecurityConference.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InformationSecurityConference.ViewModels
{
    internal class LogInViewModel:ViewModel
    {
        private string _username;
        private string _password ="231241231231";
        public string Username 
        {
            get => _username;
            set 
            { 
                if (Equals(_username, value)) return; 
                else _username= value;
                OnPropertyChanged(nameof(Username));
            } 
        }
        public string Password 
        { 
            get => _password; 
            set 
            { 
                if(Equals(_password, value)) return;
                _password= value; 
                OnPropertyChanged(nameof(Password));
            } 
        }
        public bool Authorization { get; set; }

        #region Commands
        #region LogIn
        public ICommand LogIn { get; }
        public bool CanLogInExecute(object parametr)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) return false;
            else return true;
        }
        public void OnLogInExecuted(object parametr)
        {
            using (var context = new userstoreEntities1())
            {
                var person = context.Person.FirstOrDefault(x => x.LogIn == Username) ?? null;
                if (person != null)
                {
                    if (person.Password == Password.ToString()) Authorization = true;
                }
                else Authorization = false;
            }
        }
        #endregion
        #region CloseApplication
        public ICommand CloseApplication { get; }
        public bool CanCloseApplication(object parametr) => true;
        public void OnCloseApplication(object parametr) => Application.Current.Shutdown();
        #endregion
        #region MinimizeWindow
        public ICommand MinimazeWindow { get; }
        public bool CanMinimazeWindow(object parametr) => true;
        public void OnMinimazeWindow(object parametr) => Application.Current.Windows[0].WindowState = WindowState.Minimized;
        #endregion

        #endregion
        public LogInViewModel()
        {
            LogIn = new LambdaCommand(OnLogInExecuted, CanLogInExecute);
            CloseApplication = new LambdaCommand(OnCloseApplication, CanCloseApplication);
            MinimazeWindow = new LambdaCommand(OnMinimazeWindow, CanMinimazeWindow);
        }
    }
}
