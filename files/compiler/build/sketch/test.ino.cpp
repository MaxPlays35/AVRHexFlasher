#include <Arduino.h>
#line 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
#line 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
int val; // Задаем переменную val для отслеживания нажатия клавиши
int ledpin = 13; // задаем цифровой интерфейс ввода/вывода 13 - это наш светодиод

#line 4 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void setup();
#line 10 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void loop();
#line 4 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void setup ()
{
  Serial.begin (9600); // Задаем скорость обмена com-порта 9600
  pinMode (ledpin, OUTPUT); // Задаем ledpin 13 как интерфейс вывода информации
}

void loop ()
{
  val = Serial.read (); // Считываем команду посланную с компьютера через консоль IDE Arduino
  if (val == 'R') // Задаем букву условие на букву "R", при нажатии которой в консоли будет зажигался светодиод и появится строка "Hello World!"
{
digitalWrite (ledpin, HIGH); // Включаем светодиод на 13 выходе платы
delay (2000);
digitalWrite (ledpin, LOW); // Выключаем светодиод на 13 выходе платы
Serial.println ("Hello World!"); // Пишем в консоль "Hello World!"
}
}
