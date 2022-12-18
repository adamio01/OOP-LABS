using System;

namespace lab_2{

    // Создание своего класса для вывода исключения со своим сообщением
    class EditionException : ArgumentException{
        public EditionException(string message ) // Конструктор, который создает исключение с заданным сообщением через конструктор базового класса
        :base(message){}
    }
}
