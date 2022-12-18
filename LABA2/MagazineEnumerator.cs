using System;
using System.Collections;


namespace lab_2{

    class MagazineEnumerator: IEnumerator{

        Magazine magazine;
        int position = -1;

        Person[] temp = new Person[0];
        Article[] temp1 = new Article[0];

        // Конструктор, который заполняет временные переменные (temp - массив редакторов журнала, temp1 - массив статей журнала)
        public MagazineEnumerator(Magazine magazine){
            this.magazine = magazine;
            this.temp =  (Person[])magazine.Editors.ToArray(typeof(Person));
            this.temp1 =  (Article[])magazine.Articles.ToArray(typeof(Article));
        }

        public object Current{
            get {return magazine.Articles[position];}
        }
        public bool MoveNext(){ 
            while (++position < magazine.Articles.Count && IsEditor(temp,temp1[position]));
            return position < magazine.Articles.Count;
        }
        public void Reset(){
            position = -1;
        }

        // Проверяем, есть ли авторы статьи в списке редакторов журнала
        private bool IsEditor(Person[] editors, Article article){
            return(editors.Contains(article.Pers));
        }
    }
}
