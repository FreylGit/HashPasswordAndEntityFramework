using ConsoleApp1;


List<UserData> userDatas = new  List<UserData>();

User user = InputUser();
UserData userData = new UserData();
userData.ParseUser(user);
using(var db = new UserContext())
{
    
    userData = db.Users.OrderBy(u => u.Id).First();
    userData.Show();
}



User InputUser()
{
    User user = new User();
    Console.Write("Введите логин:");
    user.Username = Console.ReadLine();
    user.Password = ChekPassword();
    Console.WriteLine("Вы зарегистрированны!");
    return user;
}


string ChekPassword()
{
    string firstPassword;
    string secondPassword;
    do
    {
        Console.Write("Введите пароль:");
        firstPassword = Console.ReadLine();
        Console.Write("Введите пароль еще раз:");
        secondPassword = Console.ReadLine();
    }
    while (!firstPassword.Equals(secondPassword));
    
    return firstPassword;
}
