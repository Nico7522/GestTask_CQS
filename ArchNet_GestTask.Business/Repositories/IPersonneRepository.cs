﻿using ArchNet_GestTask.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchNet_GestTask.Business.Repositories
{
    public interface IPersonneRepository
    {
        IEnumerable<Personne> Get();
        void Inserer(Personne entity);
        void Modifier(Personne entity);
    }
}
