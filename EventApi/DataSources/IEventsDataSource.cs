using EventApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.DataSources
{
    public interface IEventsDataSource
    {
        Event[] GetAll();

        Event GetEvent(int Id);
    }
}
