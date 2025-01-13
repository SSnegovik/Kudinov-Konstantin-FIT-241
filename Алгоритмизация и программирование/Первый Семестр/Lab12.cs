using System;

//Лабараторная работа 12 19.12.2024

class Train{
    public int TrainNumber { get; set; }
    public string OneStation { get; set; }
    public string TwoStation { get; set; }
    public TimeSpan DepartureTime { get; set; }

    public Train(int trainNumber, string oneStation, string twoStation, string departureTime)
    {
        TrainNumber = trainNumber;
        OneStation = oneStation;
        TwoStation = twoStation;
        DepartureTime = TimeSpan.Parse(departureTime);
    }

    public override string ToString(){
        return $"Поезд №{TrainNumber}: {OneStation} -> {TwoStation}, Время отправления: {DepartureTime}";
    }
}

class Station{
    public string StationName { get; set; }
    private Train[] Trains;
    private int count;

    public Station(string stationName, int capacity){
        StationName = stationName;
        Trains = new Train[capacity];
        count = 0;
    }

    public void AddTrain(Train train){
        if (count < Trains.Length){
            Trains[count] = train;
            count++;
        }
        else{
            Console.WriteLine("Невозможно добавить поезд: достигнута максимальная вместимость массива.");
        }
    }

    public Train[] GetTrainsByDestination(string destination){
        Train[] result = new Train[count];
        int resultCount = 0;

        for (int i = 0; i < count; i++){
            if (Trains[i].TwoStation == destination){
                result[resultCount] = Trains[i];
                resultCount++;
            }
        }

        Array.Resize(ref result, resultCount);
        return result;
    }

    public Train[] GetTrainsAfterTime(string time){
        TimeSpan specifiedTime = TimeSpan.Parse(time);
        Train[] result = new Train[count];
        int resultCount = 0;

        for (int i = 0; i < count; i++){
            if (Trains[i].DepartureTime > specifiedTime){
                result[resultCount] = Trains[i];
                resultCount++;
            }
        }

        Array.Resize(ref result, resultCount);
        return result;
    }
}

class Program{
    static void Main(){
        Console.Write("Введите максимальное количество поездов на станции: ");
        int capacity = int.Parse(Console.ReadLine());
        Station station = new Station("Омск", capacity);

        while (true){
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Поиск поездов по пункту назначения");
            Console.WriteLine("3. Поиск поездов по времени отправления");
            Console.WriteLine("4. Выход");

            Console.Write("Выберите пункт меню: ");
            string choice = Console.ReadLine();

            switch (choice){
                case "1":
                    Console.Write("Введите номер поезда: ");
                    int trainNumber = int.Parse(Console.ReadLine());

                    Console.Write("Введите пункт отправления: ");
                    string oneStation = Console.ReadLine();

                    Console.Write("Введите пункт назначения: ");
                    string twoStation = Console.ReadLine();

                    Console.Write("Введите время отправления (HH:MM): ");
                    string departureTime = Console.ReadLine();

                    var train = new Train(trainNumber, oneStation, twoStation, departureTime);
                    station.AddTrain(train);
                    break;

                case "2":
                    Console.Write("Введите пункт назначения: ");
                    string destination = Console.ReadLine();
                    Train[] trainsByDestination = station.GetTrainsByDestination(destination);
                    if (trainsByDestination.Length > 0){
                        foreach (var trainByDestination in trainsByDestination){
                            Console.WriteLine(trainByDestination);
                        }
                    }
                    else{
                        Console.WriteLine("Поезда с таким пунктом назначения не найдены.");
                    }
                    break;

                case "3":
                    Console.Write("Введите время (HH:MM): ");
                    string time = Console.ReadLine();
                    Train[] trainsAfterTime = station.GetTrainsAfterTime(time);
                    if (trainsAfterTime.Length > 0){
                        foreach (var trainAfterTime in trainsAfterTime){
                            Console.WriteLine(trainAfterTime);
                        }
                    }
                    else{
                        Console.WriteLine("Поезда, отправляющиеся после указанного времени, не найдены.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
