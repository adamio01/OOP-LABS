using System;

namespace lab_2{

    class Edition{
        // Защищенные поля данного класса
        protected string title;
        protected DateTime dateofpub;
        protected int circulation;

        // Конструктор для инициализации полей значениями по умолчанию
        public Edition(){
            this.title = "default";
            this.dateofpub = new DateTime(0001,1,1);
            this.circulation = 0;
        }

        // Конструктор для инициализации полей своими значениями
        public Edition(string title, DateTime date, int circulation){
            this.title = title;
            this.dateofpub = date;
            this.circulation = circulation;
        }

        // Открытые свойства для защищенных полей данного класса
        public string Title{get{return this.title;}set{this.title = value;}}
        public DateTime Dateofpub{get{return this.dateofpub;}set{this.dateofpub = value;}}
        public int Circulation{get{return this.circulation;} // Выполняем проверку при записи значения в переменную
        set{if (value < 0 ){
            throw  new EditionException("Тираж не может быть отрицательным числом");}
            else{
                this.circulation = value;
                }
            }
        }

        // Определение метода для полного копирования объекта. Возвращает новый объект класса Edition с данными изначального объекта
        public virtual Object DeepCopy(){
            Edition copy_edition = new Edition (this.title, this.dateofpub, this.circulation);
            return copy_edition;
        }

        // Определение метода сравнения двух объектов
        public override bool Equals(object obj)
        {
            if (obj == null){
                return false;
            }
            if (obj is not Edition){// Проверяем, что введенный объект является объектом класса Edition
                return false;
            }
            return (Title == ((Edition)obj).Title && Dateofpub == ((Edition)obj).Dateofpub && Circulation == ((Edition)obj).Circulation);
        }

        // Перегрузка метода получения хэш-кода
        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Dateofpub.GetHashCode() ^ Circulation.GetHashCode();
        }

        // Определение операторов сравнения
        public static bool operator == (Edition ed1, Edition ed2){
            return ed1.Equals(ed2);
        }


        public static bool operator != (Edition ed1, Edition ed2){
            return !ed1.Equals(ed2);
        }


        public override string ToString()
        {
            return($"Название: {this.title} Дата публикации: {this.dateofpub} Тираж: {this.circulation}");
        }
    }
}
