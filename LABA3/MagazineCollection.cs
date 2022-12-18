using System;

namespace lab_3{

    class MagazineCollection{
        public List<Magazine> list_of_magazines = new List<Magazine>();
        // Свойства для получения отсортированного списка журналов по разным критериям
        public List<Magazine> ByTitle{get {return this.SortByTitle();}}
        public List<Magazine> ByDateOfPub{get {return this.SortByDateOfPub();}}
        public List<Magazine> ByCirculation{get {return this.SortByCirculation();}}

        // Свойство для получения максимального среднего рейтинга статей из списка
        public double AVGRating{get {
            double maximum = 0;
            List<double> avg = new List<double>();
            foreach(Magazine a in list_of_magazines){
                avg.Add(a.Rating); // Создаем список с рейтингами всех журналов
            }
            if (avg.Count > 0) maximum = avg.Max();
            return maximum;}}

        // Свойство для получения подмножества журналов с заданной периодичностью выхода
        public IEnumerable<Magazine> ByFrequency{get {
            var selected = from p in this.list_of_magazines where p[Frequency.Monthly] == true select p; // Выбираем журналы, где частота выпуска - ежемесячно
            return selected ;
        }}

        // Метод для получения списка журналов, где средний рейтинг статей больше либо равен введеному параметру
        public List<Magazine> RatingGroup(double value){
            var result = from p in list_of_magazines group p by p.Rating into g select new {Rating = g.Key, Magazine = g.ToList()}; // Группируем журналы по рейтингу и создаем новый класс с двумя свойствами
            List<Magazine> temp = new List<Magazine>();
            foreach (var a in result){
                if (a.Rating >= value){
                    temp.AddRange(a.Magazine); // Если рейтинг больше нашего значения, добавляем лист в ответ
                }
            }
            return temp;
        }

        // Метод для сортировки списка по названию издания
        private List<Magazine> SortByTitle(){
            this.list_of_magazines.Sort();
            return list_of_magazines;
        }

        // Метод для сортировки списка по дате выхода издания
        private List<Magazine> SortByDateOfPub(){
            Edition comparer = new Edition();
            this.list_of_magazines.Sort(comparer); // Сортируем с выбранным методом для сравнения (имеется в виду метод Compare() в классе указанного объекта)
            return list_of_magazines;
        }

        // Метод для сортировки списка по тиражу
        private List<Magazine> SortByCirculation(){
            Edition.Compare comparer = new Edition.Compare();
            this.list_of_magazines.Sort(comparer);
            return list_of_magazines;
        }

        // Метод для добавления значений по умолчанию
        public void AddDefaults(){
            this.list_of_magazines.Add(new Magazine());
            this.list_of_magazines.Add(new Magazine());
            this.list_of_magazines.Add(new Magazine());
        }

        // Метод для добавления своих значений
        public void AddMagazines(params Magazine[] magazines){
            this.list_of_magazines.AddRange(magazines);
        }

        // Перегруженный метод для вывода полной информации о журналах в списке
        public override string ToString(){
            string string_magazines = "";
            for(int i = 0; i < this.list_of_magazines.Count; i++){
                string_magazines += this.list_of_magazines[i].ToString() + "\n --------------------------------\n";
            }
            return $"Список журналов:\n{string_magazines}";
        }

        // Виртуальный метод для вывода частичной информации о журналах из списка
        public virtual string ToShortString(){
            string string_magazines = "Список журналов:\n";
            for(int i = 0; i < this.list_of_magazines.Count; i++){
                string_magazines += this.list_of_magazines[i].ToShortString();
                string_magazines += $", Кол-во редакторов журнала: {this.list_of_magazines[i].Editors.Count}, ";
                string_magazines += $"Кол-во статей в журнале: {this.list_of_magazines[i].Articles.Count}";
                string_magazines+= "\n----------------------------\n";
            }
            return string_magazines;
        }
    }
}
