using System;
using System.Collections;

namespace lab_2
{
    class Program
    {
        static void Main(){
            // Создаем два объекта
            Edition v1 = new Edition();
            Edition v2 = new Edition();
            // Проверяем равенство ссылок
            System.Console.WriteLine(Object.ReferenceEquals(v1, v2));
            // Провеярем равенство объектов
            System.Console.WriteLine(v1 == v2);
            // Выводим хэш-коды объектов
            System.Console.WriteLine($"Хэш-код первого объекта v1 {v1.GetHashCode()}");
            System.Console.WriteLine($"Хэш-код первого объекта v2 {v2.GetHashCode()}");
            // Проверяем работоспособность условия записи значения
            try{
                v1.Circulation = -1;
            }
            catch(ArgumentException e){
                System.Console.WriteLine(e.Message);
            }
            // Создаем объект класса Magazine
            Magazine mag1 = new Magazine();
            // Заполняем объект
            mag1.AddArticles(new Article[] {new Article(new Person("Вячеслав", "Смирнов", new DateTime(1982,10,3)),"Иноповод", 4.5), new Article(new Person(),"Инфоповод2", 1.3)});
            mag1.AddEditors(new Person[]{new Person("Вячеслав", "Смирнов", new DateTime(1982,10,3)), new Person("Руслан", "Толмасов", new DateTime(1982,10,3))});
            // Выводим его данные
            for(int i = 0; i < mag1.Articles.Count; i++){
                System.Console.WriteLine(mag1.Articles[i]);
            }
            for(int i = 0; i < mag1.Editors.Count; i++){
                System.Console.WriteLine(mag1.Editors[i]);
            }
            System.Console.WriteLine(mag1.Edition);
            // Создаем копию объекта
            Magazine mag2 = mag1.DeepCopy();
            // Меняем данные в первоначальном объекте
            mag1.Circulation = 10;
            mag1.AddArticles(new Article[] {new Article(new Person("В", "C", new DateTime(1982,10,3)),"1", 4.5), new Article(new Person(),"2", 1.3)});
            // Сравниваем объект и его копию
            System.Console.WriteLine(mag1);
            System.Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            System.Console.WriteLine(mag2);
            System.Console.WriteLine("------------------------------------------");
            ArrayList temp = mag1.Articles;
            // Проверяем итераторы
            // Итератор с определенным рейтингом
            for(int i = 0; i < mag1.Articles.Count; i++){
                foreach(double a in mag1.ByRating( 2.0)){
                    if (a == ((Article)temp[i]).Rating){
                        System.Console.WriteLine(((Article)temp[i]));
                    }
                }
            }
            System.Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            // Итератор с определенной строкой
            for(int i = 0; i < mag1.Articles.Count; i++){
                foreach(string a in mag1.ByNameSubstring("Инф")){
                    if (a == ((Article)temp[i]).Title){
                        System.Console.WriteLine(((Article)temp[i]));
                    }
                }
            }

            System.Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            // Итератор со статьями, авторы которых не находятся в редакции журнала
            foreach(var a in mag1){
                System.Console.WriteLine(a);
            }

            System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            // Итератор со статьями, авторы которых являются редакторами журнала
            foreach(Article a in mag1.ByArticle()){
                System.Console.WriteLine(a);
            }

            System.Console.WriteLine("*************************************************");
            // Иетратор с редакторами, у которых нет статей в журнале
            foreach(Person a in mag1.ByPerson()){
                System.Console.WriteLine(a);
            }

        }
    }


    interface IRateAndCopy{
        double Rating {get;}
        object DeepCopy();
    }

    enum Frequency {Weekly, Monthly, Yearly};
}
