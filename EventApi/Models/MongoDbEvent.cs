﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApi.Models
{
    public class MongoDbEvent : Event
    {
        private int m_id;
        private ObjectId m_mongoId;

        public MongoDbEvent() 
        {
        }

        public MongoDbEvent(Event eventItem) : base(eventItem)
        {
            MongoId = new ObjectId(DateTime.UtcNow, 0, short.Parse(Id.ToString()), 0);
        }

        public ObjectId MongoId
        {
            get { return m_mongoId; }
            set
            {
                m_mongoId = value;
                Id = (int)value.Pid;
            }
        }
    }
}