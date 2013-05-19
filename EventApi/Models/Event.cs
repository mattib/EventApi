﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApi.Models
{
    public class Event
    {
        public Event()
        {
        }
        public Event(MongoDbEvent mongoDbEvent)
        {
            Id = mongoDbEvent.Id;
            Text = mongoDbEvent.Text;
            Time = mongoDbEvent.Time;
            UserId = mongoDbEvent.UserId;
            InputType = mongoDbEvent.InputType;
            RowStatus = mongoDbEvent.RowStatus;
            EventType = mongoDbEvent.EventType;
            TaskId = mongoDbEvent.TaskId;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public int InputType { get; set; }
        public int RowStatus { get; set; }
        public int EventType { get; set; }
        public int TaskId { get; set; }
    }
}