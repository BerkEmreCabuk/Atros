using Atros.Domain.Movies.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Movies.Commands
{
    public class BulkSynchronizeCommand: IRequest<int>
    {
        public List<MovieModel> MovieModels { get; set; }
    }
}
