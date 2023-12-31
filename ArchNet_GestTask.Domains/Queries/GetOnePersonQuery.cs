﻿using ArchNet_GestTask.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;

namespace ArchNet_GestTask.Domains.Queries
{
    public class GetOnePersonQuery : IQueryDefinition<Personne>
    {
        public GetOnePersonQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
