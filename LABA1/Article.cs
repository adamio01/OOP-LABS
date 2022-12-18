using System;

namespace lab_1{
    class Article{
        // Автореализуемые свойства для класса
        public Person Pers {get; set;}
        public string Title{get; set;}
        public double Rati{get;set;}

        // Конструктор для инициализации свойств своими значениями
        public Article(Person pers, string title, double rati){
            this.Pers = pers;
            this.Title = title;
            this.Rati = rati;
        }

        // Конструктор для инициализации свойств значениями по умолчанию
        public Article(){
            this.Pers = new Person() ;
            this.Title = "default Title";
            this.Rati = 0.0d;
        }

        // Перегруженный метод для вывода информации о статье
        public override string ToString()
        {
            return $"Автор {this.Pers}, Название статьи: {this.Title}, Рейтинг статьи: {this.Rati}";
        }
    }
}
