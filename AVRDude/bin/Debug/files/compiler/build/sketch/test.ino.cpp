#include <Arduino.h>
#line 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
#line 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
int val; // ������ ���������� val ��� ������������ ������� �������
int ledpin = 13; // ������ �������� ��������� �����/������ 13 - ��� ��� ���������

#line 4 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void setup();
#line 10 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void loop();
#line 4 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
void setup ()
{
  Serial.begin (9600); // ������ �������� ������ com-����� 9600
  pinMode (ledpin, OUTPUT); // ������ ledpin 13 ��� ��������� ������ ����������
}

void loop ()
{
  val = Serial.read (); // ��������� ������� ��������� � ���������� ����� ������� IDE Arduino
  if (val == 'R') // ������ ����� ������� �� ����� "R", ��� ������� ������� � ������� ����� ��������� ��������� � �������� ������ "Hello World!"
{
digitalWrite (ledpin, HIGH); // �������� ��������� �� 13 ������ �����
delay (2000);
digitalWrite (ledpin, LOW); // ��������� ��������� �� 13 ������ �����
Serial.println ("Hello World!"); // ����� � ������� "Hello World!"
}
}
