﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Laba6
{
    public class Controller
    {
        public List<Inventory> FindItemsByCostRange(Gym gym, int minCost, int maxcost)
        {
            return gym.InventoryList.FindAll(x => x.Cost <= maxcost && x.Cost >= minCost);
        }
        
        /*1.  Добавьте  в  класс-контроллер  метод,  считывающий  построчно текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию.*/
        public void CreateGymFromTextFile(Gym gym)
        {
            var stream = new StreamReader(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba6\Laba6\Data.txt");
            while (stream.ReadLine() is string line)
            switch (line)
            {
              case "Ball": gym.Add(new Ball());
                  break;
              case "Bench": gym.Add(new Bench());
                  break;
              case "Bars": gym.Add(new Bars());
                  break;
              case "Mats": gym.Add(new Mats());
                  break;
            }
        }
        
        /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию*/
        public void CreateGymFromJSONFile(Gym gym)
        {
            var stream = new StreamReader(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba6\Laba6\Data.json");
            //TODO добить json

        }
        
        
        

    }
}