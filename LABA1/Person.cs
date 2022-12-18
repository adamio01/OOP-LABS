using System;

namespace lab_1
{
    class Person
    {
        // Закрытые поля данного класса
        private string name;
        private string surname;
        private DateTime birthday;

        // Конструктор для инициализации полей значениями по умолчанию
        public Person()
        {
            this.name = "Default";
            this.surname = "Default";
            this.birthday = new DateTime(0001,1,1);

        }

        // Конструктор для инициализации полей своими значениями
        public Person(string name, string surname, DateTime birthday){
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        // Открытые свойства для закрытых полей данного класса
        public string Name {
            get {return this.name;}
            set {this.name = value;}
        }

        public string Surname {
            get {return this.surname;}
            set {this.surname = value;}
        }

        public DateTime Birthday{
            get{return this.birthday;}
            set{this.birthday = value;}
        }

        public int Year{
            get{return this.birthday.Year;}
            set{this.birthday = new DateTime(value, this.birthday.Month, this.birthday.Day) ;}
        }

        // Перегруженный метод для вывода полной информации о человеке
        public override string ToString()
        {
            return($"Имя: {this.name} Фамилия: {this.surname} Дата рождения: {this.birthday}");
        }

        // Виртуальный метод для вывода частичной информации о человеке
        public virtual string ToShortString(){
            return $"Имя: {this.name} Фамилия: {this.surname}";
        }
    }
}
