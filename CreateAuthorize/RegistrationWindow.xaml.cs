using System.Linq;
using System.Windows;

namespace CreateAuthorize{
	public partial class RegistrationWindow : Window{
		DBContainer db;

		public RegistrationWindow(){
			InitializeComponent();
			db = new DBContainer();
		}

		void RegistrationClick(object sender, RoutedEventArgs e){
			if(login.Text == "" || password.Password == "" || lastName.Text == "" || firstName.Text == "" || middleName.Text == "")
				MessageBox.Show("Ошибка: пустое поле!");
			else if(db.Users.Select(item => item.Login).Contains(login.Text))
				MessageBox.Show("Ошибка: логин занят!");
			else{
				db.Users.Add(new User(){
					Login = login.Text,
					Password = password.Password,
					LastName = lastName.Text,
					FirstName = firstName.Text,
					MiddleName = middleName.Text
				});
				db.SaveChanges();
				MessageBox.Show("Успех: регистрация!");
				new AuthorizationWindow().Show();
				Close();
			}
		}

		void CancelClick(object sender, RoutedEventArgs e){
			new AuthorizationWindow().Show();
			Close();
		}
	}
}