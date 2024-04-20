# MPEI_OS_Lab3
### Введение в операционные системы

#### Лабораторная работа № 3:  "Работа с потоками на языке С#"

Разработать программу, включающую два потока. Первичный поток
должен осуществлять общее управление работой программы. Вторичный по-
ток должен выполнять требуемые вычисления.

Вторичный поток должен выполнять вычисления по стадиям и переда-
вать после каждой стадии результаты вычислений для использования их пер-
вичным потоком.

Первичный поток должен иметь возможность визуализировать резуль-
таты вычислений каждой стадии.

Стадия - это нахождение какого-либо очередного пути или цикла.
После каждой стадии вторичный поток должен записывать результаты
вычислений в общую область данных.

Первичный поток с определённой регулярностью должен считывать
эти данные и отображать на экране.

При доступе к общим данным должно быть обеспечено взаимоисклю-
чение.

Программа должна быть написана на языке С#.
Программа должна обеспечивать ввод исходных данных из файла и с
клавиатуры.

Должен быть подготовлен тест, где стадия длится около 1 секунды, а
число стадий примерно 100.

Отчёт по лабораторной работе должен содержать:
  - Титульный лист
  - Задание на работу (общее и индивидуальное)
  - Описание работы программы
  - Алгоритм построения пути или цикла на псевдокоде
  - Тесты
  - Распечатки экранов при работе программы
  - Листинг программы.

## Индивидуальое задание

Вариант 12 

Найти кратчайший путь от одной вершины к другой, не проходящий через две заданные вершины и два заданных ребра.
