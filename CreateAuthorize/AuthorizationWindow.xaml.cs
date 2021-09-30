using System.Linq;
using System.Windows;

namespace CreateAuthorize{
	public partial class AuthorizationWindow : Window{
		DBContainer db;

		public AuthorizationWindow(){
			InitializeComponent();
			db = new DBContainer();
		}

		void AuthorizationClick(object sender, RoutedEventArgs e){
			if(login.Text == "" || password.Password == "")
				MessageBox.Show("Ошибка: пустое поле!");
			else if(db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
				MessageBox.Show("Успех: авторизация!");
			else
				MessageBox.Show("Ошибка: неверный логин или пароль!");
		}

		void RegistrationClick(object sender, RoutedEventArgs e){
			new RegistrationWindow().Show();
			Close();
		}
	}
}