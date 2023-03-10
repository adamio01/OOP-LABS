using System;

namespace lab_3{

    class Edition: IComparable<Edition>, IComparer<Edition>{
        protected string title;
        protected DateTime dateofpub;
        protected int circulation;

        public Edition(){
            this.title = "default";
            this.dateofpub = new DateTime(0001,1,1);
            this.circulation = 0;
        }


        public Edition(string title, DateTime date, int circulation){
            this.title = title;
            this.dateofpub = date;
            this.circulation = circulation;
        }


        public string Title{get{return this.title;}set{this.title = value;}}
        public DateTime Dateofpub{get{return this.dateofpub;}set{this.dateofpub = value;}}
        public int Circulation{get{return this.circulation;}
        set{if (value < 0 ){
            throw  new EditionException("Тираж не может быть отрицательным числом");}
            else{
                this.circulation = value;
                }
            }

        }


        public virtual Object DeepCopy(){
            Edition copy_edition = new Edition (this.title, this.dateofpub, this.circulation);
            return copy_edition;
        }


        public override bool Equals(object obj)
        {
            if (obj == null){
                return false;
            }
            if (obj is not Edition){
                return false;
            }
            return (Title == ((Edition)obj).Title && Dateofpub == ((Edition)obj).Dateofpub && Circulation == ((Edition)obj).Circulation);
        }

        // Метод CompareTo() (сравнивает объект, от которого вызвали метод, с введенным объектом по названию издания). Реализация интерфейса IComparable.
        public int CompareTo(Edition that){
            return this.Title.CompareTo(that.Title);
        }


        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Dateofpub.GetHashCode() ^ Circulation.GetHashCode();
        }


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

        // Метод Compare() для сравнения объектов о дате публикации. Реализация интерфейса IComparer
        int IComparer<Edition>.Compare(Edition x, Edition y)
        {
            return x.Dateofpub.CompareTo(y.Dateofpub);
        }

        // Вспомогательный класс для реализации интерфейса IComparer с методом Compare(), который сравнивает по тиражу издания.
        public class Compare: IComparer<Edition>{
            int IComparer<Edition>.Compare(Edition first, Edition second){
                return first.Circulation.CompareTo(second.Circulation);
            }
        }
    }
}
