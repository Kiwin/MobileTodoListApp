using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Services
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
