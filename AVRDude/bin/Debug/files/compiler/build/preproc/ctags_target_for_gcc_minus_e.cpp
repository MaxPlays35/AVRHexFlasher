# 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
# 1 "D:\\Dev\\GitHub_Repos\\AVRHexFlasher\\AVRDude\\bin\\Debug\\test\\test.ino"
int val; // ������ ���������� val ��� ������������ ������� �������
int ledpin = 13; // ������ �������� ��������� �����/������ 13 - ��� ��� ���������

void setup ()
{
  Serial.begin (9600); // ������ �������� ������ com-����� 9600
  pinMode (ledpin, 0x1); // ������ ledpin 13 ��� ��������� ������ ����������
}

void loop ()
{
  val = Serial.read (); // ��������� ������� ��������� � ���������� ����� ������� IDE Arduino
  if (val == 'R') // ������ ����� ������� �� ����� "R", ��� ������� ������� � ������� ����� ��������� ��������� � �������� ������ "Hello World!"
{
digitalWrite (ledpin, 0x1); // �������� ��������� �� 13 ������ �����
delay (2000);
digitalWrite (ledpin, 0x0); // ��������� ��������� �� 13 ������ �����
Serial.println ("Hello World!"); // ����� � ������� "Hello World!"
}
}
