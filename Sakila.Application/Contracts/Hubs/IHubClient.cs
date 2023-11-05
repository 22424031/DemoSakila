using Sakila.Application.Dtos.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.Hubs
{
    public interface IHubClient 
    {
        Task BroadcastMessage(MessageInstance msg);
    }
}
