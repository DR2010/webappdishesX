﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishesApi.Models
{
    public interface IDishesService
    {
        Dishes get(int id);
    }

    public class Dishes : IDishesService   {

        public Dishes()
        {
        }

        public Dishes(long inputID)
        {
            Id = inputID;
        }

        public Dishes get(int id)
        {
            throw new NotImplementedException();
        }

        public long Id { get; set; }
        public string Name { get; set; }            // name of the dish - this is the KEY, must be unique
        public string Type { get; set; }                     // type of dish, includes drinks and deserts
        public string Price { get; set; }        // preco do prato multiplicar por 100 e nao ter digits
        public string GlutenFree { get; set; }      // Gluten free dishes
        public string DairyFree { get; set; }  // Dairy Free dishes
        public string Vegetarian { get; set; }   // Vegeterian dishes
        public string InitialAvailable { get; set; }  // Number of items initially available
        public string CurrentAvailable { get; set; }// Currently available
        public string ImageName { get; set; }// Image Name
        public string Description { get; set; }              // Description of the plate
        public string Descricao { get; set; }                // Descricao do prato
        public string ActivityType { get; set; }             // Descricao do activity

    }


}
